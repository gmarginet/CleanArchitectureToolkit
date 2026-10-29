using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Telemetry;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatWorkflowProcessor"/>.
/// Gets the workflow from the service provider, builds its steps, and runs them inside a tracing activity.
/// </summary>
public class CatWorkflowProcessor : ICatWorkflowProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICatStepProcessor _stepProcessor;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Gives the workflow.</param>
    /// <param name="stepProcessor">Runs the steps.</param>
    public CatWorkflowProcessor(IServiceProvider serviceProvider, ICatStepProcessor stepProcessor)
    {
        _serviceProvider = serviceProvider;
        _stepProcessor = stepProcessor;
    }

    /// <inheritdoc />
    public async Task<ICatWorkflowResponse> RunAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflow = _serviceProvider.GetRequiredService<TWorkflow>();
        var workflowName = workflow.GetType().Name;
        var workflowBuilder = new CatWorkflowBuilder<TWorkflowState>();

        workflow.Build(workflowBuilder);

        using var activity = CatWorkFlowActivitySource.CreateActivity($"Processing Workflow {workflowName}");

        var result = await _stepProcessor.RunStepsAsync(workflowBuilder, workflowState, cancellationToken);
        
        return result.WorkflowResult == CatStepExecutionResult.BreakFromCurrentFlowOnly
            ? result.ChangeWorkflowResult(CatStepExecutionResult.Continue)
            : result;
    }
}