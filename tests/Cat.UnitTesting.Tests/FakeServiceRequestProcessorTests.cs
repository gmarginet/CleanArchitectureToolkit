using Cat.Responses;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.ServiceRequests;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class FakeServiceRequestProcessorTests
{
    private sealed class PingRequest : ICatServiceRequest
    {
        public string Name { get; set; } = "";
    }

    private sealed class CountRequest : ICatServiceRequest<int>
    {
        public string Filter { get; set; } = "";
    }

    [Test]
    public async Task ProcessAsync_WithoutASetup_ShouldAnswerTheDefaultResponseAndRecordTheRequest()
    {
        var fake = new FakeServiceRequestProcessor();
        var request = new PingRequest();

        var response = await fake.ProcessAsync(request);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(fake.Requests, Is.EqualTo(new object[] { request }));
        }
    }

    [Test]
    public void Process_WithAFunction_ShouldBuildTheResponseFromTheRequest()
    {
        var fake = new FakeServiceRequestProcessor()
            .Respond<PingRequest>(request => request.Name == "" ? CatResponse.BadRequest() : CatResponse.Ok());

        var empty = fake.Process(new PingRequest());
        var named = fake.Process(new PingRequest { Name = "a" });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(empty.IsFailed, Is.True);
            Assert.That(named.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task ProcessAsync_WithAResult_ShouldAnswerTheSetUpResponse()
    {
        var fake = new FakeServiceRequestProcessor().Respond<CountRequest, int>(request => CatResponse.Ok(request.Filter.Length));

        var response = await fake.ProcessAsync(new CountRequest { Filter = "abc" });

        Assert.That(response.Value, Is.EqualTo(3));
    }

    [Test]
    public void Process_WithAResultAndNoSetup_ShouldThrowAndStillRecordTheRequest()
    {
        var fake = new FakeServiceRequestProcessor();
        var request = new CountRequest();

        var exception = Assert.Throws<NotSupportedException>(() => fake.Process(request));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(exception.Message, Does.Contain(nameof(CountRequest)));
            Assert.That(fake.Requests, Is.EqualTo(new object[] { request }));
        }
    }

    [Test]
    public void Reset_ShouldClearTheRequestsTheSetupsAndTheDefault()
    {
        var fake = new FakeServiceRequestProcessor { DefaultResponse = CatResponse.Conflict() }
            .Respond<PingRequest>(CatResponse.NotFound());
        fake.Process(new PingRequest());

        fake.Reset();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fake.Requests, Is.Empty);
            Assert.That(fake.Process(new PingRequest()).IsSucceeded, Is.True);
        }
    }

    [Test]
    public void Of_ShouldGiveTheRequestsOfOneTypeInOrder()
    {
        var fake = new FakeServiceRequestProcessor().Respond<CountRequest, int>(CatResponse.Ok(1));
        var first = new PingRequest { Name = "a" };
        var second = new PingRequest { Name = "b" };

        fake.Process(first);
        fake.Process(new CountRequest());
        fake.Process(second);

        Assert.That(fake.Of<PingRequest>(), Is.EqualTo(new[] { first, second }));
    }
}
