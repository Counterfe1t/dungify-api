using Dungify.Core.Abstractions;
using Dungify.Infrastructure.Auth;
using Dungify.Infrastructure.Configuration;
using Dungify.Infrastructure.DAL;
using Dungify.Infrastructure.DAL.Queries;
using Dungify.Infrastructure.Logging;
using Dungify.Infrastructure.Middleware;
using Dungify.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TimeProvider = Dungify.Infrastructure.Time.TimeProvider;

namespace Dungify.Infrastructure;

public static class Extensions
{
    private const string AppSectionName = "app";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<AppOptions>(AppSectionName);
        services.Configure<AppOptions>(configuration.GetSection(AppSectionName));

        services.AddSingleton<ExceptionMiddleware>()
            .AddSingleton<ITimeProvider, TimeProvider>()
            .AddHttpContextAccessor()
            .AddCustomLogging()
            .AddDatabase(configuration)
            .AddQueries()
            .AddSecurity()
            .AddAuth(configuration);

        services.AddSwaggerGen(swagger =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JSON Web Token Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token in the textbox below!",
                Reference = new()
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme,
                }
            };

            swagger.AddSecurityDefinition("Bearer", jwtSecurityScheme);
            swagger.AddSecurityRequirement(new()
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });

            swagger.EnableAnnotations();
            swagger.SwaggerDoc(options.Version, new()
            {
                Title = options.Name,
                Version = options.Version,
            });
        });

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();

        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }

}