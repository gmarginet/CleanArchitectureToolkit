using Cat.Demo.PaymentService.CoreService;
using Cat.Demo.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.Configure<PaymentFailureOptions>(builder.Configuration.GetSection(PaymentFailureOptions.SectionName));
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSingleton<PaymentProcessor>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Takes a payment. A declined payment answers 200 with Approved false. A failure that was switched on answers 503.
app.MapPost("/payments", async (PaymentRequest request, PaymentProcessor processor, CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(request.OrderNumber) || request.Amount <= 0)
    {
        return Results.BadRequest(new { error = "An order number and an amount above zero are required." });
    }

    var outcome = await processor.ProcessAsync(request, cancellationToken);

    return outcome.Failed
        ? Results.Problem("The payment service is failing on purpose.", statusCode: StatusCodes.Status503ServiceUnavailable)
        : Results.Ok(outcome.Response);
});

app.Run();
