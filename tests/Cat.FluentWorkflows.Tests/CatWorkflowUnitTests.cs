using System.Diagnostics;
using System.Linq.Expressions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Steps;
using Cat.FluentWorkflows.Telemetry;
using Cat.FluentWorkflows.Tests.Steps;
using Cat.FluentWorkflows.Tests.Workflows;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.FluentWorkflows.Tests;

public class StepParameterSource
{
    public string? Text { get; set; }
}

public class StepParameterTarget
{
    public string? Text { get; set; } = "preset";
    public int Number { get; set; } = 5;
}

[TestFixture]
public class CatStepParameterTests
{
    private static CatStepParameter TextParameter() => new(
        (Expression<Func<StepParameterSource, string?>>)(s => s.Text),
        (Expression<Func<StepParameterTarget, string?>>)(t => t.Text));

    [Test]
    public void Assign_CopiesTheValue()
    {
        var target = new StepParameterTarget();

        TextParameter().Assign(new StepParameterSource { Text = "hello" }, target);

        Assert.That(target.Text, Is.EqualTo("hello"));
    }

    [Test]
    public void Assign_NullSource_WritesTheDefault()
    {
        var target = new StepParameterTarget();

        TextParameter().Assign(new StepParameterSource { Text = null }, target);

        Assert.That(target.Text, Is.Null);
    }

    [Test]
    public void Constructor_TargetIsNotAMember_Throws()
    {
        Assert.Throws<NotSupportedException>(() => new CatStepParameter(
            (Expression<Func<StepParameterSource, string?>>)(s => s.Text),
            (Expression<Func<StepParameterTarget, int>>)(t => t.Number + 1)));
    }
}

[TestFixture]
public class CatWorkflowResponseTests
{
    private static readonly ICatError Error = CatError.Create("T-1", "failed");

    [Test]
    public void Succeeded_HasNoErrors()
    {
        var response = CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);

        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(response.ErrorList, Is.Empty);
    }

    [Test]
    public void Failed_KeepsErrorsAndResult()
    {
        var response = CatWorkflowResponse.Failed(CatStepExecutionResult.BreakCascade, Error);

        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(response.ErrorList, Is.EqualTo(new[] { Error }));
    }

    [Test]
    public void Failed_WithList_KeepsErrors()
    {
        var response = CatWorkflowResponse.Failed(CatStepExecutionResult.Continue, (IReadOnlyList<ICatError>)new List<ICatError> { Error });

        Assert.That(response.ErrorList, Has.Count.EqualTo(1));
    }

    [Test]
    public void ChangeWorkflowResult_ChangesTheResultAndReturnsTheSameResponse()
    {
        var response = CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);

        var changed = response.ChangeWorkflowResult(CatStepExecutionResult.BreakCascade);

        Assert.That(changed, Is.SameAs(response));
        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
    }

    [Test]
    public void Cast_SucceededResponse_HasNoErrors()
    {
        var response = CatResponseExtensions.Cast(CatResponse.Ok(), CatStepExecutionResult.Continue);

        Assert.That(response.ErrorList, Is.Empty);
        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
    }

    [Test]
    public void Cast_FailedResponse_CarriesErrorsAndTheGivenResult()
    {
        var response = CatResponseExtensions.Cast(CatResponse.BadRequest(Error), CatStepExecutionResult.Continue);

        Assert.That(response.ErrorList, Has.Count.EqualTo(1));
        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
    }

    [Test]
    public void Cast_Generic_DefaultsToContinueAndDropsThePayload()
    {
        var response = CatResponse.Ok("payload").Cast();

        Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(response.ErrorList, Is.Empty);
    }
}

[TestFixture]
public class ModuleRegistrationTests
{
    [Test]
    public void AddCatFluentWorkflowsModule_RegistersProcessorsScopedAndStepsTransient()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatFluentWorkflowsModule();

        Assert.That(services.Single(d => d.ServiceType == typeof(ICatStepProcessor)).Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
        Assert.That(services.Single(d => d.ServiceType == typeof(ICatWorkflowProcessor)).Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
        Assert.That(services.Single(d => d.ServiceType == typeof(CatBreakStep)).Lifetime, Is.EqualTo(ServiceLifetime.Transient));
        Assert.That(services.Any(d => d.ServiceType == typeof(CatWhileStep<>)));
    }

    [Test]
    public void AddCatFluentWorkflowsSteps_RegistersPublicNonGenericStepsOnly()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatFluentWorkflowsSteps(typeof(NullableInputStep));

        Assert.That(services.Any(d => d.ServiceType == typeof(NullableInputStep)));
        Assert.That(services.Any(d => d.ServiceType == typeof(UnregisteredStep)), Is.False);
        Assert.That(services.Any(d => d.ServiceType.IsGenericType && d.ServiceType.GetGenericTypeDefinition() == typeof(GenericStep<>)), Is.False);
    }

    [Test]
    public void AddCatFluentWorkflowsFlows_RegistersPublicWorkflowsOnly()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatFluentWorkflowsFlows(typeof(LogLevelsFlow));

        Assert.That(services.Any(d => d.ServiceType == typeof(LogLevelsFlow)));
        Assert.That(services.Any(d => d.ServiceType == typeof(UnregisteredFlow)), Is.False);
    }
}

[TestFixture]
public class WorkflowTracingTests : Cat.NUnit.UnitTestBase
{
    private readonly List<Activity> _started = [];
    private ActivityListener _listener = null!;

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsFlows(typeof(LogLevelsFlow));
    }

    [SetUp]
    public void SetUp()
    {
        _started.Clear();
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == CatWorkFlowActivitySource.ActivitySourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity => { lock (_started) _started.Add(activity); }
        };
        ActivitySource.AddActivityListener(_listener);
    }

    [TearDown]
    public void TearDown() => _listener.Dispose();

    [Test]
    public async Task Run_StartsAnActivityNamedAfterTheWorkflow()
    {
        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();

        await processor.RunAsync<LogLevelsFlow, LogLevelsFlowState>(new LogLevelsFlowState(), CancellationToken.None);

        Assert.That(_started.Select(a => a.OperationName), Has.Some.Contain("Processing Workflow").And.Some.Contain(nameof(LogLevelsFlow)));
    }
}
