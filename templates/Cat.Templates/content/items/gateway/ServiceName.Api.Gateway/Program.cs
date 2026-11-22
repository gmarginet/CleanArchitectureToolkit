using Cat.Api.Gateway;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

// The module reads the CatGateway section of appsettings.json: the token provider and the services behind the gateway.
builder.Services.AddCatApiGateway(builder.Configuration);

var app = builder.Build();

app.UseCatApiGateway();

// The gateway is closed by default, so the health checks say so when they are meant for everyone.
app.MapHealthChecks("/health").AllowAnonymous();
app.MapHealthChecks("/alive", new HealthCheckOptions { Predicate = check => check.Tags.Contains("live") }).AllowAnonymous();

app.MapCatApiGateway();

app.Run();
