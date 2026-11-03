using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.TodoService.DataModels.Entities;

namespace Cat.Demo.TodoService.Infrastructure.Database;

public class DemoDatabase : IDemoDatabase
{
    private readonly IDictionary<Guid, Todo> _todoTable = new Dictionary<Guid, Todo>();
    private readonly SemaphoreSlim _todoSemaphoreSlim = new(1, 1);

    public DemoDatabase()
    {
        _todoSemaphoreSlim.Wait();

        try
        {
            _todoTable.Add(TodoHelper.Todo1.Id, TodoHelper.Todo1);
            _todoTable.Add(TodoHelper.Todo2.Id, TodoHelper.Todo2);
            _todoTable.Add(TodoHelper.Todo3.Id, TodoHelper.Todo3);
            _todoTable.Add(TodoHelper.Todo4.Id, TodoHelper.Todo4);
        }
        finally
        {
   
            _todoSemaphoreSlim.Release();
        }
    }

    public Task<IList<Todo>> GetTodoListAsync(Guid? todoCategoryId, CancellationToken ct = default)
    {
        var query = _todoTable.Values.AsQueryable();

        if (todoCategoryId is not null)
        {
            query = query.Where(x => x.CategoryId == todoCategoryId);    
        }
        
        var result = query.ToList();
        return Task.FromResult<IList<Todo>>(result);
    }

    public Task<Todo?> GetTodoAsync(Guid id, CancellationToken ct = default)
    {
        _todoTable.TryGetValue(id, out var todo); 
        return Task.FromResult(todo);
    }

    public Task<Guid> SaveAsync(Todo todo, CancellationToken ct = default)
    {
        _todoSemaphoreSlim.Wait(ct);

        try
        {
            if (_todoTable.TryGetValue(todo.Id, out var existingTodo))
            {
                existingTodo.CategoryId = todo.CategoryId;
                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                
                return Task.FromResult(todo.Id);
            }

            _todoTable.Add(todo.Id, todo);
            
            return Task.FromResult(todo.Id);
        }
        finally
        {
   
            _todoSemaphoreSlim.Release();
        }
    }
}
