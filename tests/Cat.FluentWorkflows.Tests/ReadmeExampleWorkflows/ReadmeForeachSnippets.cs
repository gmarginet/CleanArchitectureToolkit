using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeForeachSnippetsState : ICatWorkflowState<ReadmeForeachSnippetsState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public decimal Total { get; set; }
    public int Attempts { get; set; }
}

public record OrderLineState : ICatForeachState<OrderLine, ReadmeForeachSnippetsState>, ICatWorkflowState<OrderLineState>
{
    public OrderLine CurrentItem { get; set; } = null!;
    public ReadmeForeachSnippetsState ParentWorkflowState { get; set; } = null!;
    public decimal LineTotal { get; set; }
}

public class ReadmeForeachSnippets : ICatWorkflow<ReadmeForeachSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeForeachSnippetsState> builder)
    {
        builder.Foreach(s => s.Lines, loop =>
        {
            loop.Run(item => item.ParentWorkflowState.Total += item.CurrentItem.Quantity * item.CurrentItem.Price);
        });

        builder.Foreach<ReadmeForeachSnippetsState, OrderLine, OrderLineState>(s => s.Lines, loop =>
        {
            loop.Set(l => l.LineTotal, l => l.CurrentItem.Quantity * l.CurrentItem.Price);
            loop.Run(l => l.ParentWorkflowState.Total += l.LineTotal);
        });

        builder.Foreach(s => s.Lines, loop =>
        {
            loop.BreakFromLoopIf(item => item.CurrentItem.Quantity == 0);
            loop.Run(item => item.ParentWorkflowState.Attempts++);
        });
    }
}
