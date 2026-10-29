using Cat.Commands.Abstractions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ProcessCommandFlowState : ICatWorkflowState<ProcessCommandFlowState>
{
    public string Name { get; set; } = "";
    public List<string> Trace { get; } = [];
}

public record TestPingCommand(string Text) : ICatCommand
{
    public TestPingCommand() : this("")
    {
    }
}

public class TestPingCommandHandler : ICatCommandHandler<TestPingCommand>
{
    public Task<ICatResponse> HandleAsync(TestPingCommand command, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse>(command.Text == "fail"
            ? CatResponse.BadRequest(CatError.Create("X-2", "ping failed"))
            : CatResponse.Ok());
    }
}

public class ProcessCommandFlow : ICatWorkflow<ProcessCommandFlowState>
{
    public void Build(ICatWorkflowBuilder<ProcessCommandFlowState> builder)
    {
        builder.ProcessCommand<ProcessCommandFlowState, TestPingCommand>()
            .Input(s => s.Name, step => step.Command.Text);
        builder.Run(s => s.Trace.Add("after-command"));
    }
}
