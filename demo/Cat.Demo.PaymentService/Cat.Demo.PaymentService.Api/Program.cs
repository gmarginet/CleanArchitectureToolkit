using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Cat.Demo.PaymentService.Api.Extensions;
using Cat.Demo.PaymentService.CoreService;
using Cat.Demo.ServiceDefaults;
using Cat.ServiceRequests.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// The default document describes a decimal as a double, and so does the generated client. Say decimal, so money stays decimal.
builder.Services.AddOpenApi(options => options.AddSchemaTransformer((schema, context, _) =>
{
    if ((Nullable.GetUnderlyingType(context.JsonTypeInfo.Type) ?? context.JsonTypeInfo.Type) == typeof(decimal))
    {
        schema.Format = "decimal";
    }

    return Task.CompletedTask;
}));

// Numbers are numbers only, so the OpenAPI document describes the amount as a number and not as a number or a string.
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict);

builder.Services.Configure<PaymentFailureOptions>(builder.Configuration.GetSection(PaymentFailureOptions.SectionName));
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSingleton<PaymentProcessor>();

// The listener for the TakePayment messages of Orders. It is on when the host gives Payment the connection string "messaging".
// The handler uses the same processor as the HTTP endpoint, so the failure settings and the ledger apply to both.
builder.Services.AddCatServiceRequestsModule(typeof(TakePaymentHandler));
var messagingOn = builder.Services.AddCatDemoPaymentMessaging(builder.Configuration);

// With an authority in the configuration (the AppHost sets it) the service checks the token the gateway forwards.
// Without one, a plain dotnet run keeps working with no login.
var authenticationOn = builder.AddDemoJwtAuthentication();

var app = builder.Build();

if (authenticationOn)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    if (messagingOn)
    {
        await app.Services.InitializePaymentMessagingAsync();
    }
}

app.MapDefaultEndpoints();

// Takes a payment. A declined payment answers 200 with Approved false. A failure that was switched on answers 503.
// The path starts with the name of the service, as the gateway routes it.
var payments = app.MapPost("/payment/payments", async (PaymentRequest request, PaymentProcessor processor, CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(request.OrderNumber) || request.Amount <= 0)
    {
        return Results.BadRequest(new { error = "An order number and an amount above zero are required." });
    }

    var outcome = await processor.ProcessAsync(request, cancellationToken);

    return outcome.Failed
        ? Results.Problem("The payment service is failing on purpose.", statusCode: StatusCodes.Status503ServiceUnavailable)
        : Results.Ok(outcome.Response);
})
.Produces<PaymentResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status503ServiceUnavailable)
.WithName("TakePayment");

if (authenticationOn)
{
    payments.RequireAuthorization();
}

app.Run();
