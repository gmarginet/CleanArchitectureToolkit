using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatStepProcessor"/>.
/// For each step it gets the step body from the service provider, fills the inputs, runs the step and copies the outputs.
/// It stops after a step that returns BreakCascade, BreakFromCurrentFlowOnly or BreakFromLoop.
/// The result is the one of the last step that ran. The errors of every step that ran are kept.
/// </summary>
public class CatStepProcessor : ICatStepProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CatStepProcessor> _logger;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Gives the step bodies. Every step body must be registered.</param>
    /// <param name="logger">Logs problems with inputs and outputs.</param>
    public CatStepProcessor(IServiceProvider serviceProvider, ILogger<CatStepProcessor> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    
    /// <inheritdoc />
    /// <exception cref="ArgumentNullException">The workflow state is <c>null</c>.</exception>
    public async Task<ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(ICatWorkflowBuilder<TWorkflowState> workflowBuilder, TWorkflowState workflowState,
        CancellationToken cancellationToken)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        if (workflowState == null)
        {
            throw new ArgumentNullException(nameof(workflowState));
        }

        var result = CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
        var errors = new List<ICatError>();

        foreach (var workflowStep in workflowBuilder.WorkflowSteps)
        {
            var body = (ICatStepBodyAsync)_serviceProvider.GetRequiredService(workflowStep.BodyType);
            var stepBodyName = body.GetType().Name;

            try
            {
                if (body is ICatStepBodyWithState<TWorkflowState> bodyWithState)
                {
                    bodyWithState.WorkflowState = workflowState;
                }

                foreach (var input in workflowStep.Inputs)
                {
                    input.Assign(workflowState, body);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not assign inputs of WorkflowStep {workflowStep}", stepBodyName);
                throw;
            }

            result = await body.RunAsync(cancellationToken);
            errors.AddRange(result.ErrorList);

            try
            {
                foreach (var output in workflowStep.Outputs)
                {
                    output.Assign(body, workflowState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not assign outputs of WorkflowStep {workflowStep}", stepBodyName);
                throw;
            }

            if (result.WorkflowResult is CatStepExecutionResult.BreakCascade or CatStepExecutionResult.BreakFromCurrentFlowOnly or CatStepExecutionResult.BreakFromLoop)
            {
                break;
            }
        }

        return CatWorkflowResponse.WithErrors(result, errors);
    }
}