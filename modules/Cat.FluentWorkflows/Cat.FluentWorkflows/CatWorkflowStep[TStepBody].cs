using System;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows;

/// <summary>
/// A workflow step that runs the step body <typeparamref name="TStepBody"/>.
/// </summary>
/// <typeparam name="TStepBody">The step body to run.</typeparam>
public class CatWorkflowStep<TStepBody> : CatWorkflowStep
    where TStepBody : ICatStepBodyAsync
{
    /// <inheritdoc />
    public override Type BodyType => typeof(TStepBody);
}