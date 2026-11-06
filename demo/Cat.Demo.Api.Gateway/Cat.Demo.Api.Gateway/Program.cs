using Cat.Api.Gateway;
using Cat.Demo.ServiceDefaults;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// The module reads the CatGateway section. The Aspire service discovery resolves addresses like http://catalog.
builder.Services.AddCatApiGateway(builder.Configuration)
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.UseCatApiGateway();

// The gateway is closed by default, so the health checks say so when they are meant for everyone.
app.MapHealthChecks("/health").AllowAnonymous();
app.MapHealthChecks("/alive", new HealthCheckOptions { Predicate = check => check.Tags.Contains("live") }).AllowAnonymous();

app.MapCatApiGateway();

app.Run();
