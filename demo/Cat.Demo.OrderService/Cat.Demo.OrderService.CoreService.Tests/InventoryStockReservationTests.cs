using System.Net;
using System.Text;
using System.Text.Json;
using Cat.Demo.InventoryService.Api.Client;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.Inventory;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class InventoryStockReservationTests
{
    private static readonly Guid BookA = Guid.NewGuid();
    private static readonly Guid BookB = Guid.NewGuid();

    private sealed class StubHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> respond) : HttpMessageHandler
    {
        public List<(HttpMethod Method, string? Path, string Body)> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add((request.Method, request.RequestUri?.AbsolutePath, request.Content is null ? "" : await request.Content.ReadAsStringAsync(cancellationToken)));
            return await respond(request);
        }
    }

    private static HttpResponseMessage Json(HttpStatusCode status, string json) =>
        new(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

    private static InventoryStockReservation Reservation(StubHandler handler) =>
        new(new InventoryClient(new HttpClient(handler) { BaseAddress = new Uri("http://gateway") }), NullLogger<InventoryStockReservation>.Instance);

    private static readonly StockReservationLine[] Lines =
    [
        new(BookA, "9780141036144", 2),
        new(BookB, "9780261103573", 1)
    ];

    [Test]
    public async Task AnOkAnswer_ShouldBeReservedAndSendTheOrderNumberAndTheIsbnLines()
    {
        var handler = new StubHandler(_ => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        var result = await Reservation(handler).ReserveAsync("20261106-0001", Lines);

        Assert.That(result, Is.EqualTo(new StockReservationResult(true, null)));
        var request = handler.Requests.Single();
        Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
        Assert.That(request.Path, Is.EqualTo("/inventory/reservations"));
        using var body = JsonDocument.Parse(request.Body);
        Assert.That(body.RootElement.GetProperty("OrderNumber").GetString(), Is.EqualTo("20261106-0001"));
        var lines = body.RootElement.GetProperty("Lines");
        Assert.That(lines.GetArrayLength(), Is.EqualTo(2));
        Assert.That(lines[0].GetProperty("Isbn").GetString(), Is.EqualTo("9780141036144"));
        Assert.That(lines[0].GetProperty("Quantity").GetInt32(), Is.EqualTo(2));
    }

    [Test]
    public async Task AConflict_ShouldBeOutOfStockForTheBookOfTheIsbnInTheError()
    {
        var handler = new StubHandler(_ => Task.FromResult(Json(HttpStatusCode.Conflict,
            """{"status":409,"catErrors":[{"code":"DEM-INV-1000","message":"Not enough stock for {Isbn}.","arguments":["9780261103573"]}]}""")));

        var result = await Reservation(handler).ReserveAsync("20261106-0001", Lines);

        Assert.That(result, Is.EqualTo(new StockReservationResult(false, BookB)));
    }

    [Test]
    public async Task ANotFound_WithoutAReadableBody_ShouldBeOutOfStockForTheFirstBook()
    {
        var handler = new StubHandler(_ => Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)));

        var result = await Reservation(handler).ReserveAsync("20261106-0001", Lines);

        Assert.That(result, Is.EqualTo(new StockReservationResult(false, BookA)));
    }

    [TestCase(HttpStatusCode.ServiceUnavailable)]
    [TestCase(HttpStatusCode.InternalServerError)]
    [TestCase(HttpStatusCode.Unauthorized)]
    public async Task AnErrorStatus_ShouldBeUnavailable(HttpStatusCode status)
    {
        var handler = new StubHandler(_ => Task.FromResult(new HttpResponseMessage(status)));

        var result = await Reservation(handler).ReserveAsync("20261106-0001", Lines);

        Assert.That(result, Is.EqualTo(new StockReservationResult(false, null, Unavailable: true)));
    }

    [Test]
    public async Task AFailedCall_ShouldBeUnavailable()
    {
        var handler = new StubHandler(_ => throw new HttpRequestException("connection refused"));

        var result = await Reservation(handler).ReserveAsync("20261106-0001", Lines);

        Assert.That(result.Unavailable, Is.True);
    }

    [Test]
    public void ACancelledCall_ShouldThrow()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();
        var handler = new StubHandler(_ => throw new OperationCanceledException());

        Assert.That(() => Reservation(handler).ReserveAsync("20261106-0001", Lines, cts.Token), Throws.InstanceOf<OperationCanceledException>());
    }

    [Test]
    public async Task Release_ShouldDeleteTheReservationOfTheOrder()
    {
        var handler = new StubHandler(_ => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

        await Reservation(handler).ReleaseAsync("20261106-0001");

        var request = handler.Requests.Single();
        Assert.That(request.Method, Is.EqualTo(HttpMethod.Delete));
        Assert.That(request.Path, Is.EqualTo("/inventory/reservations/20261106-0001"));
    }

    [Test]
    public async Task Release_WhenTheServiceFails_ShouldNotThrow()
    {
        var handler = new StubHandler(_ => throw new HttpRequestException("connection refused"));

        Assert.That(() => Reservation(handler).ReleaseAsync("20261106-0001"), Throws.Nothing);
        await Task.CompletedTask;
    }
}
