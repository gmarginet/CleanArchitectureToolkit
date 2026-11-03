using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.ToDoService.Core.Queries;
using Cat.Demo.TodoService.Infrastructure.Database;
using Cat.Demo.TodoService.DataModels.Entities;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Validators;

namespace Cat.Demo.TodoService.Infrastructure.QueryHandlers;

public class TodoGetQueryHandler : ICatQueryHandler<TodoGetQuery, Todo>
{
    private readonly IDemoDatabase _demoDatabase;

    public TodoGetQueryHandler(IDemoDatabase demoDatabase)
    {
        _demoDatabase = demoDatabase;
    }
    
    public async Task<ICatResponse<Todo>> HandleAsync(TodoGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await _demoDatabase.GetTodoAsync(query.TodoId, cancellationToken);
        return result is null
            ? CatResponse.NotFound<Todo>(
                CatError.Create(
                    code: CatDemoErrorDefinitions.NotFound.Code,
                    message: CatDemoErrorDefinitions.NotFound.Message,
                    "Todo",
                    query.TodoId
                    )
              )
            : CatResponse.Ok(result);
    }
}
