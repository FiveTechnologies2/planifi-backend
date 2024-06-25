using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Planifi_backend.IAM.Application.Internal.CommandServices;
using Planifi_backend.IAM.Application.Internal.OutboundServices;
using Planifi_backend.IAM.Application.Internal.QueryServices;
using Planifi_backend.IAM.Domain.Repositories;
using Planifi_backend.IAM.Domain.Services;
using Planifi_backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using Planifi_backend.IAM.Infrastructure.Persistence.EFC.Repositories;
using Planifi_backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Planifi_backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using Planifi_backend.IAM.Infrastructure.Tokens.JWT.Services;
using Planifi_backend.IAM.Interfaces.ACL;
using Planifi_backend.IAM.Interfaces.ACL.Services;
using Planifi_backend.Profiles.Application.Internal.CommandServices;
using Planifi_backend.Profiles.Application.Internal.QueryServices;
using Planifi_backend.Profiles.Domain.Repositories;
using Planifi_backend.Profiles.Domain.Services;
using Planifi_backend.Profiles.Infrastructure.Persistence.EFC.Repositories;
using Planifi_backend.Profiles.Interfaces.ACL;
using Planifi_backend.Profiles.Interfaces.ACL.Services;
using Planifi_backend.Shared.Domain.Repositories;
using Planifi_backend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo()
            {
                Title = "Planifi.API",
                Version = "v1",
                Description = "Planifi API",
                TermsOfService = new Uri("https://planifi.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Planifi Studios",
                    Email = "contact@planifi.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

// IAM Bound Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

// Add authorization middleware to pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();