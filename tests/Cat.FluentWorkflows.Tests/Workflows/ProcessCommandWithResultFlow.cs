using Cat.Commands.Abstractions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ProcessCommandWithResultFlowState : ICatWorkflowState<ProcessCommandWithResultFlowState>
{
    public string Name { get; set; } = "";
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public record TestCreateCommand(string Text) : ICatCommand<int>
{
    public TestCreateCommand() : this("")
    {
    }
}

public class TestCreateCommandHandler : ICatCommandHandler<TestCreateCommand, int>
{
    public Task<ICatResponse<int>> HandleAsync(TestCreateCommand command, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<int>>(command.Text == "fail"
            ? CatResponse.BadRequest<int>(CatError.Create("X-3", "create failed"))
            : CatResponse.Ok(11));
    }
}

public class ProcessCommandWithResultFlow : ICatWorkflow<ProcessCommandWithResultFlowState>
{
    public void Build(ICatWorkflowBuilder<ProcessCommandWithResultFlowState> builder)
    {
        builder.ProcessCommand<ProcessCommandWithResultFlowState, TestCreateCommand, int>()
            .Input(s => s.Name, step => step.Command.Text)
            .Output(step => step.Response!.Value, s => s.Number);
        builder.Run(s => s.Trace.Add("after-command"));
    }
}
