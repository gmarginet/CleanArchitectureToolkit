using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.TodoService.Models.Entities;

namespace Cat.Demo.TodoService.Infrastructure.Database;

public class DemoDatabase : IDemoDatabase
{
    private readonly IDictionary<int, Todo> _todoTable = new Dictionary<int, Todo>();
    private readonly SemaphoreSlim _todoSemaphoreSlim = new(1, 1);

    public DemoDatabase()
    {
        _todoSemaphoreSlim.Wait();

        try
        {
            _todoTable.Add(TodoHelper.Todo1.Id!.Value, TodoHelper.Todo1);
            _todoTable.Add(TodoHelper.Todo2.Id!.Value, TodoHelper.Todo2);
            _todoTable.Add(TodoHelper.Todo3.Id!.Value, TodoHelper.Todo3);
            _todoTable.Add(TodoHelper.Todo4.Id!.Value, TodoHelper.Todo4);
        }
        finally
        {
   
            _todoSemaphoreSlim.Release();
        }
    }

    public Task<IList<Todo>> GetTodoListAsync(int? todoCategoryId, CancellationToken cancellationToken = default)
    {
        var query = _todoTable.Values.AsQueryable();

        if (todoCategoryId is not null)
        {
            query = query.Where(x => x.CategoryId == todoCategoryId);    
        }
        
        var result = query.ToList();
        return Task.FromResult<IList<Todo>>(result);
    }

    public Task<Todo?> GetTodoAsync(int id, CancellationToken cancellationToken = default)
    {
        _todoTable.TryGetValue(id, out var todo); 
        return Task.FromResult(todo);
    }

    public Task<int> SaveAsync(Todo todo, CancellationToken cancellationToken = default)
    {
        _todoSemaphoreSlim.Wait(cancellationToken);

        try
        {
            if (todo.Id is not null && _todoTable.TryGetValue(todo.Id.Value, out var existingTodo))
            {
                existingTodo.CategoryId = todo.CategoryId;
                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                
                return Task.FromResult(todo.Id.Value);
            }

            var maxId = _todoTable.Keys.Max();
            var newId = maxId + 1;
            
            todo.Id = newId;
            _todoTable.Add(newId, todo);
            
            return Task.FromResult(newId);
        }
        finally
        {
   
            _todoSemaphoreSlim.Release();
        }
    }
}