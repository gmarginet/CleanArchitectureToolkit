using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.Steps;

/// <summary>
/// Starts with a preset value, so a test can see whether an input overwrote it.
/// </summary>
public class NullableInputStep : CatStepBody
{
    public NullableInputStep(ILogger<NullableInputStep> logger) : base(logger)
    {
    }

    public string? Value { get; set; } = "preset";

    public int Number { get; set; } = 99;

    public bool ValueWasNull { get; private set; }

    protected override ICatWorkflowResponse Run()
    {
        ValueWasNull = Value is null;
        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}

/// <summary>
/// A generic step body. The module skips generic step bodies when it scans.
/// </summary>
public class GenericStep<T> : CatStepBody
{
    public GenericStep(ILogger<GenericStep<T>> logger) : base(logger)
    {
    }

    protected override ICatWorkflowResponse Run()
    {
        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}

/// <summary>
/// An internal step body. The module only scans public classes, so nobody registers this one.
/// </summary>
internal class UnregisteredStep : CatStepBody
{
    public UnregisteredStep(ILogger<UnregisteredStep> logger) : base(logger)
    {
    }

    protected override ICatWorkflowResponse Run()
    {
        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
