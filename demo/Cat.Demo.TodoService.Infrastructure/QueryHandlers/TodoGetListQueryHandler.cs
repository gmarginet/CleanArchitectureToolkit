using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.ToDoService.Core.Queries;
using Cat.Demo.TodoService.Infrastructure.Database;
using Cat.Demo.TodoService.Models.Entities;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.TodoService.Infrastructure.QueryHandlers;

public class TodoGetListQueryHandler : ICatQueryHandler<TodoGetListQuery, IList<Todo>>
{
    private readonly IDemoDatabase _demoDatabase;

    public TodoGetListQueryHandler(IDemoDatabase demoDatabase)
    {
        _demoDatabase = demoDatabase;
    }

    public async Task<ICatResponse<IList<Todo>>> HandleAsync(TodoGetListQuery query, CancellationToken cancellationToken = default)
    {
        var todoList = await _demoDatabase.GetTodoListAsync(query.TodoCategoryId, cancellationToken);
        return CatResponse.Ok(todoList);
    }
}