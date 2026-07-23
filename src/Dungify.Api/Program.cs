using Dungify.Application;
using Dungify.Core;
using Dungify.Infrastructure;
using Dungify.Infrastructure.Configuration;
using Dungify.Infrastructure.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();
app.MapGet("/api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name)).WithMetadata(new SwaggerOperationAttribute("Get API name."));
app.UseInfrastructure();
app.Run();