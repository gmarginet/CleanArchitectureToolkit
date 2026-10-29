using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.TodoService.Events.ServiceRequests;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.ToDoService.Core.ServiceRequestHandlers;

public class TodoSaveRequestHandler : ICatServiceRequestHandler<TodoSaveRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public TodoSaveRequestHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }
    
    public async Task<ICatResponse> HandleAsync(TodoSaveRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var command = serviceRequest.ToCommand();
        var response = await _commandProcessor.ProcessAsync(command, cancellationToken);

        return response;
    }
}