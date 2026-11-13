using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.UnitTesting.Queries;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class FakeQueryProcessorTests
{
    private sealed class CountQuery : ICatQuery<int>
    {
        public string Filter { get; set; } = "";
    }

    private sealed class NameQuery : ICatQuery<string>;

    [Test]
    public async Task ProcessAsync_WithASetup_ShouldAnswerItAndRecordTheQuery()
    {
        var fake = new FakeQueryProcessor().Respond<CountQuery, int>(CatResponse.Ok(5));
        var query = new CountQuery();

        var response = await fake.ProcessAsync(query);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Value, Is.EqualTo(5));
            Assert.That(fake.Queries, Is.EqualTo(new object[] { query }));
        }
    }

    [Test]
    public void Process_WithAFunction_ShouldBuildTheResponseFromTheQuery()
    {
        var fake = new FakeQueryProcessor()
            .Respond<CountQuery, int>(query => CatResponse.Ok(query.Filter.Length));

        var response = fake.Process(new CountQuery { Filter = "abcd" });

        Assert.That(response.Value, Is.EqualTo(4));
    }

    [Test]
    public void Process_WithAFailedResponse_ShouldAnswerTheFailure()
    {
        var fake = new FakeQueryProcessor().Respond<NameQuery, string>(CatResponse.NotFound<string>());

        var response = fake.Process(new NameQuery());

        Assert.That(response.IsFailed, Is.True);
    }

    [Test]
    public void Process_WithoutASetup_ShouldThrowAndStillRecordTheQuery()
    {
        var fake = new FakeQueryProcessor();
        var query = new NameQuery();

        var exception = Assert.Throws<NotSupportedException>(() => fake.Process(query));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(exception.Message, Does.Contain(nameof(NameQuery)));
            Assert.That(fake.Queries, Is.EqualTo(new object[] { query }));
        }
    }

    [Test]
    public void Of_ShouldGiveTheQueriesOfOneTypeInOrder()
    {
        var fake = new FakeQueryProcessor()
            .Respond<CountQuery, int>(CatResponse.Ok(1))
            .Respond<NameQuery, string>(CatResponse.Ok("a"));
        var first = new CountQuery { Filter = "a" };
        var second = new CountQuery { Filter = "b" };

        fake.Process(first);
        fake.Process(new NameQuery());
        fake.Process(second);

        Assert.That(fake.Of<CountQuery>(), Is.EqualTo(new[] { first, second }));
    }

    [Test]
    public void Reset_ShouldClearTheQueriesAndTheSetups()
    {
        var fake = new FakeQueryProcessor().Respond<NameQuery, string>(CatResponse.Ok("a"));
        fake.Process(new NameQuery());

        fake.Reset();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fake.Queries, Is.Empty);
            Assert.Throws<NotSupportedException>(() => fake.Process(new NameQuery()));
        }
    }
}
