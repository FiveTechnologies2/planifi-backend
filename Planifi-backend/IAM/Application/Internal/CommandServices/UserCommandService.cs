using System.Reflection.Metadata;
using Planifi_backend.IAM.Application.Internal.OutboundServices;
using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Domain.Repositories;
using Planifi_backend.IAM.Domain.Services;
using Planifi_backend.Shared.Domain.Repositories;

namespace Planifi_backend.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService) : IUserCommandService
{
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByEmail(command.Email))
            throw new Exception($"Email {command.Email} is already taken");
        
        var hashedPassword = hashingService.HashPassword(command.Passowrd);
        var user = new User(command.Email, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error ocurred while creating the user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);

        if (user is null || !hashingService.VerifyPassword(command.Passowrd, user.PasswordHash))
            throw new Exception("Invalid email or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
}