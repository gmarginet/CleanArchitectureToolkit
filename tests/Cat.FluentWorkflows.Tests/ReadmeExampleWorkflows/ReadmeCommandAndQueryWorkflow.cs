using Cat.Commands.Abstractions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeCommandAndQueryWorkflowState : ICatWorkflowState<ReadmeCommandAndQueryWorkflowState>
{
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public string Status { get; set; } = "New";
}

public record SaveOrderCommand(string Status) : ICatCommand
{
    public SaveOrderCommand() : this("")
    {
    }
}

public class SaveOrderCommandHandler : ICatCommandHandler<SaveOrderCommand>
{
    public static string? LastStatus { get; private set; }

    public Task<ICatResponse> HandleAsync(SaveOrderCommand command, CancellationToken cancellationToken = default)
    {
        LastStatus = command.Status;
        return Task.FromResult<ICatResponse>(CatResponse.Ok());
    }
}

public record GetDiscountQuery : ICatQuery<decimal>
{
    public decimal Total { get; set; }
}

public class GetDiscountQueryHandler : ICatQueryHandler<GetDiscountQuery, decimal>
{
    public Task<ICatResponse<decimal>> HandleAsync(GetDiscountQuery query, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<decimal>>(CatResponse.Ok(query.Total * 0.1m));
    }
}

public class ReadmeCommandAndQueryWorkflow : ICatWorkflow<ReadmeCommandAndQueryWorkflowState>
{
    public void Build(ICatWorkflowBuilder<ReadmeCommandAndQueryWorkflowState> builder)
    {
        builder.ProcessCommand<ReadmeCommandAndQueryWorkflowState, SaveOrderCommand>()
            .Input(s => s.Status, step => step.Command.Status);

        builder.ProcessQuery<ReadmeCommandAndQueryWorkflowState, GetDiscountQuery, decimal>()
            .Input(s => s.Total, step => step.Query.Total)
            .Output(step => step.Response!.Value, s => s.Discount);
    }
}
