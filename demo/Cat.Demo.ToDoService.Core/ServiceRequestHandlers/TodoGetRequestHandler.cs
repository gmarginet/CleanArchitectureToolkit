using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.TodoService.Events.Models;
using Cat.Demo.TodoService.Events.ServiceRequests;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.ToDoService.Core.ServiceRequestHandlers;

public class TodoGetRequestHandler : ICatServiceRequestHandler<TodoGetRequest, TodoModel>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public TodoGetRequestHandler(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }
    
    public async Task<ICatResponse<TodoModel>> HandleAsync(TodoGetRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var query = serviceRequest.ToQuery();
        var response = await _queryProcessor.ProcessAsync(query, cancellationToken);

        return response.Cast(x => x.ToModel());
    }
}