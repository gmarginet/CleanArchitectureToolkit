using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Steps;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.FluentWorkflows.Tests;

public record InlineFuncStepTestState : ICatWorkflowState<InlineFuncStepTestState>
{
    public int Calls { get; set; }
}

[TestFixture]
public class InlineFuncStepTests
{
    private static readonly ICatError Error = CatError.Create("T-1", "first");

    private static CatInlineFuncStep<InlineFuncStepTestState> CreateStep(
        Func<ILogger, InlineFuncStepTestState, ICatResponse<CatStepExecutionResult>>? body)
        => new(NullLogger<CatInlineFuncStep<InlineFuncStepTestState>>.Instance)
        {
            Body = body,
            WorkflowState = new InlineFuncStepTestState()
        };

    [Test]
    public void RunAsync_WithoutABody_Throws()
    {
        var step = CreateStep(null);

        var exception = Assert.ThrowsAsync<ArgumentNullException>(() => step.RunAsync());

        Assert.That(exception!.ParamName, Is.EqualTo("Body"));
    }

    [Test]
    public async Task RunAsync_SucceededBody_ReturnsTheResultOfTheBody()
    {
        var step = CreateStep((_, _) => CatResponse.Ok(CatStepExecutionResult.Continue));

        var response = await step.RunAsync();

        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(response.ErrorList, Is.Empty);
    }

    [Test]
    public async Task RunAsync_FailedBody_BreaksTheCascadeAndPassesTheErrorsOn()
    {
        var step = CreateStep((_, _) => CatResponse.BadRequest<CatStepExecutionResult>(Error));

        var response = await step.RunAsync();

        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(response.ErrorList, Is.EqualTo(new[] { Error }));
    }

    [Test]
    public async Task RunAsync_GivesTheBodyTheLoggerAndTheWorkflowState()
    {
        ILogger? receivedLogger = null;
        InlineFuncStepTestState? receivedState = null;
        var step = CreateStep((logger, state) =>
        {
            receivedLogger = logger;
            receivedState = state;
            state.Calls++;
            return CatResponse.Ok(CatStepExecutionResult.Continue);
        });

        await step.RunAsync();

        Assert.That(receivedLogger, Is.Not.Null);
        Assert.That(receivedState, Is.SameAs(step.WorkflowState));
        Assert.That(step.WorkflowState.Calls, Is.EqualTo(1));
    }
}
