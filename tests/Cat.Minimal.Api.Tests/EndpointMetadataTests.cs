using Cat.Minimal.Api.Tests.Helpers;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;

namespace Cat.Minimal.Api.Tests;

/// <summary>
/// Checks the endpoint metadata, which is what an OpenAPI generator turns into the documented responses.
/// </summary>
[TestFixture]
public class EndpointMetadataTests
{
    private const string Json = "application/json";
    private const string ProblemJson = "application/problem+json";

    private TestApp _app = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        _app = await TestApp.StartAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _app.DisposeAsync();
    }

    private int[] StatusCodes(string httpMethod, string pattern)
        => _app.GetProducedResponses(httpMethod, pattern).Select(response => response.StatusCode).ToArray();

    private IProducesResponseTypeMetadata Response(string httpMethod, string pattern, int statusCode)
        => _app.GetProducedResponses(httpMethod, pattern).Single(response => response.StatusCode == statusCode);

    private static bool HasNoBody(IProducesResponseTypeMetadata response)
        => response.Type is null || response.Type == typeof(void);

    #region The documented status codes

    [Test]
    public void Get_DocumentsTheGivenResponseTypesAndTheOnesThatAlwaysCanHappen()
    {
        Assert.That(StatusCodes("GET", "/items/{id:int}"), Is.EquivalentTo(new[] { 200, 400, 404, 409, 401, 403, 500 }));
    }

    [Test]
    public void Get_DocumentsOnlyTheGivenResponseTypes()
    {
        Assert.That(StatusCodes("GET", "/restricted/{id:int}"), Is.EquivalentTo(new[] { 200, 404, 400, 500 }));
    }

    [Test]
    public void Get_WithoutResponseTypes_DocumentsTheDefault()
    {
        Assert.That(StatusCodes("GET", "/defaults/{id:int}"), Is.EquivalentTo(new[] { 200, 400, 500 }));
    }

    [Test]
    public void Get_WithDuplicateResponseTypes_DocumentsEachStatusCodeOnce()
    {
        Assert.That(StatusCodes("GET", "/duplicates/{id:int}"), Is.EquivalentTo(new[] { 200, 404, 400, 500 }));
    }

    [Test]
    public void Post_WithAValue_DocumentsCreatedAndTheBodyRelatedStatusCodes()
    {
        Assert.That(StatusCodes("POST", "/items"), Is.EquivalentTo(new[] { 201, 409, 400, 500, 415 }));
    }

    [Test]
    public void Post_WithoutAValue_DocumentsTheDefault()
    {
        Assert.That(StatusCodes("POST", "/ping"), Is.EquivalentTo(new[] { 201, 400, 500 }));
    }

    [Test]
    public void Put_WithoutResponseTypes_DocumentsNoContent()
    {
        Assert.That(StatusCodes("PUT", "/items/{id:int}"), Is.EquivalentTo(new[] { 204, 400, 500, 415 }));
    }

    [Test]
    public void Patch_GivenResponseTypesReplaceTheDefault()
    {
        Assert.That(StatusCodes("PATCH", "/items/{id:int}"), Is.EquivalentTo(new[] { 200, 404, 400, 500, 415 }));
    }

    [Test]
    public void Delete_DocumentsTheGivenResponseTypes()
    {
        Assert.That(StatusCodes("DELETE", "/items/{id:int}"), Is.EquivalentTo(new[] { 204, 404, 400, 500 }));
    }

    [Test]
    public void PatchDocument_DocumentsNoContentAndTheBodyRelatedStatusCodes()
    {
        Assert.That(StatusCodes("PATCH", "/items/{id:int}/document"), Is.EquivalentTo(new[] { 204, 400, 500, 415 }));
    }

    #endregion The documented status codes

    #region 415

    [Test]
    public void AnEndpointThatReadsABody_Documents415()
    {
        Assert.That(StatusCodes("POST", "/items"), Does.Contain(415));
        Assert.That(StatusCodes("PUT", "/items/{id:int}"), Does.Contain(415));
    }

    [Test]
    public void AnEndpointWithoutABody_DoesNotDocument415()
    {
        Assert.That(StatusCodes("GET", "/items/{id:int}"), Does.Not.Contain(415));
        Assert.That(StatusCodes("POST", "/ping"), Does.Not.Contain(415));
        Assert.That(StatusCodes("DELETE", "/items/{id:int}"), Does.Not.Contain(415));
    }

    #endregion 415

    #region The documented bodies

    [Test]
    public void Get_Ok_DocumentsTheValueAsJson()
    {
        var response = Response("GET", "/items/{id:int}", 200);

        Assert.That(response.Type, Is.EqualTo(typeof(ItemModel)));
        Assert.That(response.ContentTypes, Is.EquivalentTo(new[] { Json }));
    }

    [Test]
    public void GetList_Ok_DocumentsTheList()
    {
        Assert.That(Response("GET", "/items", 200).Type, Is.EqualTo(typeof(IList<ItemModel>)));
    }

    [Test]
    public void GetPagedList_Ok_DocumentsThePage()
    {
        Assert.That(Response("GET", "/items/paged", 200).Type, Is.EqualTo(typeof(ICatPagedList<ItemModel>)));
    }

    [Test]
    public void Post_Created_DocumentsTheCreatedValue()
    {
        var response = Response("POST", "/items", 201);

        Assert.That(response.Type, Is.EqualTo(typeof(ItemModel)));
        Assert.That(response.ContentTypes, Is.EquivalentTo(new[] { Json }));
    }

    [Test]
    public void Post_Accepted_DocumentsTheAcceptedValue()
    {
        var response = Response("POST", "/items-accepted", 202);

        Assert.That(response.Type, Is.EqualTo(typeof(ItemModel)));
        Assert.That(response.ContentTypes, Is.EquivalentTo(new[] { Json }));
    }

    [Test]
    public void Post_AcceptedWithoutAValue_DocumentsNoBody()
    {
        Assert.That(HasNoBody(Response("POST", "/ping-accepted", 202)), Is.True);
    }

    [Test]
    public void Post_WithoutAValue_DocumentsCreatedWithoutABody()
    {
        Assert.That(HasNoBody(Response("POST", "/ping", 201)), Is.True);
    }

    [Test]
    public void SucceededResponsesWithoutAValue_DocumentNoBody()
    {
        Assert.That(HasNoBody(Response("PUT", "/items/{id:int}", 204)), Is.True);
        Assert.That(HasNoBody(Response("PATCH", "/items/{id:int}", 200)), Is.True);
        Assert.That(HasNoBody(Response("DELETE", "/items/{id:int}", 204)), Is.True);
    }

    [TestCase(400)]
    [TestCase(401)]
    [TestCase(403)]
    [TestCase(404)]
    [TestCase(409)]
    [TestCase(500)]
    public void FailedResponses_DocumentProblemDetails(int statusCode)
    {
        var response = Response("GET", "/items/{id:int}", statusCode);

        Assert.That(response.Type, Is.EqualTo(typeof(CatProblemDetails)));
        Assert.That(response.ContentTypes, Is.EquivalentTo(new[] { ProblemJson }));
    }

    [Test]
    public void The415Response_DocumentsProblemDetails()
    {
        var response = Response("POST", "/items", 415);

        Assert.That(response.Type, Is.EqualTo(typeof(CatProblemDetails)));
        Assert.That(response.ContentTypes, Is.EquivalentTo(new[] { ProblemJson }));
    }

    #endregion The documented bodies

    #region Patch document

    [Test]
    public void PatchDocument_AcceptsAJsonPatchDocument()
    {
        var accepts = _app.GetEndpoint("PATCH", "/items/{id:int}/document").Metadata.OfType<IAcceptsMetadata>().ToList();

        Assert.That(accepts.Any(metadata => metadata.ContentTypes.Contains("application/json-patch+json")), Is.True);
        Assert.That(accepts.Any(metadata => metadata.RequestType == typeof(JsonPatchDocument<ItemPatchModel>)), Is.True);
    }

    #endregion Patch document
}
