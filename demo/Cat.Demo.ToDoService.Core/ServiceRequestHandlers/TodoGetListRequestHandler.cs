using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.TodoService.Events.Models;
using Cat.Demo.TodoService.Events.ServiceRequests;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.ToDoService.Core.ServiceRequestHandlers;

public class TodoGetListRequestHandler : ICatServiceRequestHandler<TodoGetListRequest,IList<TodoModel>>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public TodoGetListRequestHandler(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }
    
    public async Task<ICatResponse<IList<TodoModel>>> HandleAsync(TodoGetListRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        //throw new NullReferenceException();
        var query = serviceRequest.ToQuery();
        var response = await _queryProcessor.ProcessAsync(query, cancellationToken);

        return response.Cast<IList<TodoModel>>(x => [.. x.Select(y => y.ToModel())]);
    }
}