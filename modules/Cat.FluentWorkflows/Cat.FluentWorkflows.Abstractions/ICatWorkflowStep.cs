using System;
using System.Collections.Generic;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// One step in a workflow: the step body to run and how it connects to the state.
/// </summary>
public interface ICatWorkflowStep
{
    /// <summary>
    /// The type of the step body. The step processor gets it from the service provider.
    /// </summary>
    Type BodyType { get; }

    /// <summary>
    /// The values copied from the state into the step before it runs.
    /// </summary>
    List<ICatStepParameter> Inputs { get; }

    /// <summary>
    /// The values copied from the step into the state after it ran.
    /// </summary>
    List<ICatStepParameter> Outputs { get; }
}