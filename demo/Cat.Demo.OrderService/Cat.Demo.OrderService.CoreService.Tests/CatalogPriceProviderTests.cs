using System.Net;
using System.Text;
using Cat.Demo.OrderService.Infrastructure.Catalog;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class CatalogPriceProviderTests
{
    private static readonly Guid BookA = Guid.Parse("6f1c0a7e-5c0e-4a53-9d4b-1d3a3b8d0001");
    private static readonly Guid BookB = Guid.Parse("6f1c0a7e-5c0e-4a53-9d4b-1d3a3b8d0002");

    private static CatalogPriceProvider CreateProvider(StubHandler handler)
        => new(new HttpClient(handler) { BaseAddress = new Uri("http://catalog") }, NullLogger<CatalogPriceProvider>.Instance);

    private static HttpResponseMessage Json(HttpStatusCode status, string json)
        => new(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

    [Test]
    public async Task Ok_ReturnsThePriceOfEachBook()
    {
        var handler = new StubHandler(_ => Json(HttpStatusCode.OK,
            $$"""[{"bookId":"{{BookA}}","price":29.95},{"bookId":"{{BookB}}","price":9.5}]"""));

        var response = await CreateProvider(handler).GetPricesAsync([BookA, BookB]);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value![BookA], Is.EqualTo(29.95m));
        Assert.That(response.Value![BookB], Is.EqualTo(9.5m));
    }

    [Test]
    public async Task Ok_SendsOneBookIdsValuePerBook()
    {
        var handler = new StubHandler(_ => Json(HttpStatusCode.OK,
            $$"""[{"bookId":"{{BookA}}","price":1},{"bookId":"{{BookB}}","price":2}]"""));

        await CreateProvider(handler).GetPricesAsync([BookA, BookB]);

        Assert.That(handler.Requests, Has.Count.EqualTo(1));
        Assert.That(handler.Requests[0].Method, Is.EqualTo(HttpMethod.Get));
        Assert.That(handler.Requests[0].PathAndQuery, Is.EqualTo($"/catalog/books/prices?bookIds={BookA}&bookIds={BookB}"));
    }

    [Test]
    public async Task NotFound_ReturnsAFailedResponseWithPriceUnavailableForTheMissingBook()
    {
        var handler = new StubHandler(_ => Json(HttpStatusCode.NotFound,
            $$"""{"status":404,"catErrors":[{"code":"CAT-CTL-1001","message":"Book {BookId} does not exist or has no price.","arguments":["{{BookB}}"]}]}"""));

        var response = await CreateProvider(handler).GetPricesAsync([BookA, BookB]);

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.NotFound>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.PriceUnavailable.Code));
        Assert.That(response.ErrorList.Single().Arguments, Is.EqualTo(new object[] { BookB }));
    }

    [Test]
    public async Task NotFound_WithAnUnreadableBody_StillFailsWithPriceUnavailable()
    {
        var handler = new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.NotFound));

        var response = await CreateProvider(handler).GetPricesAsync([BookA]);

        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.NotFound>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.PriceUnavailable.Code));
    }

    [TestCase(HttpStatusCode.BadRequest)]
    [TestCase(HttpStatusCode.InternalServerError)]
    [TestCase(HttpStatusCode.ServiceUnavailable)]
    public async Task OtherStatus_ReturnsAnErrorResponse(HttpStatusCode status)
    {
        var handler = new StubHandler(_ => new HttpResponseMessage(status));

        var response = await CreateProvider(handler).GetPricesAsync([BookA]);

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.InternalServerError>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo(CatGeneralErrorDefinitions.UnexpectedResponse.Code));
    }

    [Test]
    public async Task Ok_WithAMissingBook_ReturnsAnErrorResponse()
    {
        var handler = new StubHandler(_ => Json(HttpStatusCode.OK, $$"""[{"bookId":"{{BookA}}","price":29.95}]"""));

        var response = await CreateProvider(handler).GetPricesAsync([BookA, BookB]);

        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.InternalServerError>());
    }

    [Test]
    public async Task Ok_WithABrokenBody_ReturnsAnErrorResponse()
    {
        var handler = new StubHandler(_ => Json(HttpStatusCode.OK, "{not json"));

        var response = await CreateProvider(handler).GetPricesAsync([BookA]);

        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.InternalServerError>());
    }

    [Test]
    public async Task NetworkError_ReturnsAnErrorResponse()
    {
        var handler = new StubHandler(_ => throw new HttpRequestException("No connection."));

        var response = await CreateProvider(handler).GetPricesAsync([BookA]);

        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.InternalServerError>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo(CatGeneralErrorDefinitions.UnexpectedResponse.Code));
    }

    [Test]
    public async Task Timeout_ReturnsAnErrorResponse()
    {
        var handler = new StubHandler(_ => throw new TaskCanceledException("The request timed out."));

        var response = await CreateProvider(handler).GetPricesAsync([BookA]);

        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.InternalServerError>());
    }

    [Test]
    public async Task CancelledByTheCaller_Throws()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();
        var handler = new StubHandler(_ => throw new TaskCanceledException());

        await Assert.ThrowsAsync<TaskCanceledException>(() => CreateProvider(handler).GetPricesAsync([BookA], cts.Token));
    }

    /// <summary>Answers every request with the result of a function and remembers the requests.</summary>
    private sealed class StubHandler(Func<HttpRequestMessage, HttpResponseMessage> respond) : HttpMessageHandler
    {
        public List<(HttpMethod Method, string PathAndQuery)> Requests { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add((request.Method, request.RequestUri!.PathAndQuery));
            return Task.FromResult(respond(request));
        }
    }
}
