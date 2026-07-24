using Dungify.Application;
using Dungify.Core;
using Dungify.Infrastructure;
using Dungify.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();
app.UseInfrastructure();
app.Run();