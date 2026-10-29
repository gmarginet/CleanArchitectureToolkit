using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ProcessQueryFlowState : ICatWorkflowState<ProcessQueryFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public record TestAskQuery : ICatQuery<int>;

public class TestAskQueryHandler : ICatQueryHandler<TestAskQuery, int>
{
    public Task<ICatResponse<int>> HandleAsync(TestAskQuery query, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<int>>(CatResponse.Ok(7));
    }
}

public class ProcessQueryFlow : ICatWorkflow<ProcessQueryFlowState>
{
    public void Build(ICatWorkflowBuilder<ProcessQueryFlowState> builder)
    {
        builder.ProcessQuery<ProcessQueryFlowState, TestAskQuery, int>()
            .Output(step => step.Response!.Value, s => s.Number);
        builder.Run(s => s.Trace.Add("after-query"));
    }
}
