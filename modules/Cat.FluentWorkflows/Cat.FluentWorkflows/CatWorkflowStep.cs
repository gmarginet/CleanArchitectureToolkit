using System;
using System.Collections.Generic;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class of a workflow step.
/// </summary>
public abstract class CatWorkflowStep : ICatWorkflowStep
{
    /// <inheritdoc />
    public abstract Type BodyType { get; }

    /// <inheritdoc />
    public List<ICatStepParameter> Inputs { get; } = [];

    /// <inheritdoc />
    public List<ICatStepParameter> Outputs { get; } = [];
}