using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Expressions.Extensions;
using Cat.Minimal.Api.Extensions;
using Cat.Queries.Decorators.Logging.Extensions;
using Cat.Queries.Extensions;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Cat.ServiceRequests.Decorators.ActivitySource.Extensions;
using Cat.ServiceRequests.Decorators.Logging.Extensions;
using Cat.ServiceRequests.Decorators.Validation.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.Telemetry.Extensions;
using Cat.Validators.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ServiceName.Api.Extensions;
using ServiceName.CoreService;
using ServiceName.Infrastructure.DataAccess;
using ServiceName.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Telemetry and resilient HTTP clients, the calls that ServiceDefaults makes in the demo. Point OTEL_EXPORTER_OTLP_ENDPOINT at your collector.
builder.AddCatTelemetry();
builder.Services.ConfigureHttpClientDefaults(http => http.AddCatResilience(CatResilienceProfile.Internal));

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);
builder.Services.AddOpenApi();

// Each module finds its handlers in the assembly of the type that you give it.
builder.Services.AddCatMinimalApiModule();
builder.Services.AddCatCompiledMemberExpressionCache();
builder.Services.AddCatValidatorsModule(typeof(ServiceShortErrorDefinitions));
builder.Services.AddCatServiceRequestsModule(typeof(ServiceShortErrorDefinitions));
builder.Services.AddCatQueriesModule(typeof(ServiceShortDbContext));
builder.Services.AddCatCommandsModule(typeof(ServiceShortDbContext));

var connectionString = builder.Configuration.GetConnectionString("servicelower")
    ?? throw new InvalidOperationException("Connection string 'servicelower' is missing.");
builder.Services.AddServiceShortDatabase(connectionString);
#if (Jobs)
builder.Services.AddServiceShortScheduler(builder.Configuration);
#endif
#if (Messages)
builder.Services.AddServiceShortMessageHandlers(builder.Configuration);
#endif

var app = builder.Build();
app.UseCatMinimalApiModule();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
#if (!DatabaseFirst)
    await app.Services.InitializeServiceShortDatabaseAsync();
#endif
#if (Messages)
    await app.Services.InitializeServiceShortMessageHandlersAsync();
#endif
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");
app.MapHealthChecks("/alive", new HealthCheckOptions { Predicate = check => check.Tags.Contains("live") });
app.MapServiceShortEndpoints();

app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatServiceRequestsModuleActivitySourceDecorator();
app.Services.AddCatQueriesModuleLoggingDecorator();
app.Services.AddCatCommandsModuleLoggingDecorator();

app.Run();
