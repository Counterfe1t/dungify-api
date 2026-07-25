using Dungify.Application;
using Dungify.Core;
using Dungify.Infrastructure;
using Dungify.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.UseSerilog();
builder.Services.AddHealthChecks();
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();
app.MapHealthChecks("/api/health");
app.UseInfrastructure();
app.Run();