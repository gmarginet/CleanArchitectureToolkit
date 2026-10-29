using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.TodoService.Models.Entities;

namespace Cat.Demo.TodoService.Infrastructure.Database;

public interface IDemoDatabase
{
    Task<IList<Todo>> GetTodoListAsync(int? todoCategoryId, CancellationToken cancellationToken = default);
    Task<Todo?> GetTodoAsync(int id, CancellationToken cancellationToken = default);
    Task<int> SaveAsync(Todo todo, CancellationToken cancellationToken = default);
}