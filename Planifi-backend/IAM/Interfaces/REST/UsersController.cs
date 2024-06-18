using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Planifi_backend.IAM.Domain.Model.Queries;
using Planifi_backend.IAM.Domain.Services;
using Planifi_backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Planifi_backend.IAM.Interfaces.REST.Transform;

namespace Planifi_backend.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}