using Cat.Commands.Abstractions;
using Cat.Responses;
using Cat.UnitTesting.Commands;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class FakeCommandProcessorTests
{
    private sealed class RenameCommand : ICatCommand
    {
        public string Name { get; set; } = "";
        public int Id { get; set; }
    }

    private sealed class DeleteCommand : ICatCommand;

    private sealed class CreateCommand : ICatCommand<int>
    {
        public string Name { get; set; } = "";
    }

    [Test]
    public async Task ProcessAsync_WithoutASetup_ShouldAnswerTheDefaultResponseAndRecordTheCommand()
    {
        var fake = new FakeCommandProcessor();
        var command = new RenameCommand { Name = "a" };

        var response = await fake.ProcessAsync(command);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(fake.Commands, Is.EqualTo(new object[] { command }));
        }
    }

    [Test]
    public void Process_WithAChangedDefaultResponse_ShouldAnswerIt()
    {
        var fake = new FakeCommandProcessor { DefaultResponse = CatResponse.Conflict() };

        var response = fake.Process(new RenameCommand());

        Assert.That(response.IsFailed, Is.True);
    }

    [Test]
    public void Process_WithAResponsePerType_ShouldAnswerOnlyThatType()
    {
        var fake = new FakeCommandProcessor().Respond<DeleteCommand>(CatResponse.NotFound());

        var deleted = fake.Process(new DeleteCommand());
        var renamed = fake.Process(new RenameCommand());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(deleted.IsFailed, Is.True);
            Assert.That(renamed.IsSucceeded, Is.True);
        }
    }

    [Test]
    public void Process_WithAFunction_ShouldBuildTheResponseFromTheCommand()
    {
        var fake = new FakeCommandProcessor()
            .Respond<RenameCommand>(command => command.Name == "" ? CatResponse.BadRequest() : CatResponse.Ok());

        var empty = fake.Process(new RenameCommand());
        var named = fake.Process(new RenameCommand { Name = "a" });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(empty.IsFailed, Is.True);
            Assert.That(named.IsSucceeded, Is.True);
        }
    }

    [Test]
    public void Process_WithAFunction_ShouldLetTheTestChangeTheCommandLikeAHandler()
    {
        var fake = new FakeCommandProcessor().Respond<RenameCommand>(command =>
        {
            command.Id = 7;
            return CatResponse.Ok();
        });
        var command = new RenameCommand();

        fake.Process(command);

        Assert.That(command.Id, Is.EqualTo(7));
    }

    [Test]
    public async Task ProcessAsync_WithAResult_ShouldAnswerTheSetUpResponse()
    {
        var fake = new FakeCommandProcessor().Respond<CreateCommand, int>(CatResponse.Ok(42));

        var response = await fake.ProcessAsync(new CreateCommand());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(response.Value, Is.EqualTo(42));
        }
    }

    [Test]
    public void Process_WithAResultAndAFunction_ShouldBuildTheResultFromTheCommand()
    {
        var fake = new FakeCommandProcessor()
            .Respond<CreateCommand, int>(command => CatResponse.Ok(command.Name.Length));

        var response = fake.Process(new CreateCommand { Name = "abc" });

        Assert.That(response.Value, Is.EqualTo(3));
    }

    [Test]
    public void Process_WithAResultAndNoSetup_ShouldThrow()
    {
        var fake = new FakeCommandProcessor();

        var exception = Assert.Throws<NotSupportedException>(() => fake.Process(new CreateCommand()));

        Assert.That(exception.Message, Does.Contain(nameof(CreateCommand)));
    }

    [Test]
    public void Process_WithAResultAndNoSetup_ShouldStillRecordTheCommand()
    {
        var fake = new FakeCommandProcessor();
        var command = new CreateCommand();

        Assert.Throws<NotSupportedException>(() => fake.Process(command));

        Assert.That(fake.Commands, Is.EqualTo(new object[] { command }));
    }

    [Test]
    public void Of_ShouldGiveTheCommandsOfOneTypeInOrder()
    {
        var fake = new FakeCommandProcessor().Respond<CreateCommand, int>(CatResponse.Ok(1));
        var first = new RenameCommand { Name = "a" };
        var second = new RenameCommand { Name = "b" };

        fake.Process(first);
        fake.Process(new DeleteCommand());
        fake.Process(new CreateCommand());
        fake.Process(second);

        Assert.That(fake.Of<RenameCommand>(), Is.EqualTo(new[] { first, second }));
    }

    [Test]
    public void Reset_ShouldClearTheCommandsTheSetupsAndTheDefault()
    {
        var fake = new FakeCommandProcessor { DefaultResponse = CatResponse.Conflict() }
            .Respond<DeleteCommand>(CatResponse.NotFound());
        fake.Process(new DeleteCommand());

        fake.Reset();
        var response = fake.Process(new DeleteCommand());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fake.Commands, Has.Count.EqualTo(1));
            Assert.That(response.IsSucceeded, Is.True);
        }
    }
}
