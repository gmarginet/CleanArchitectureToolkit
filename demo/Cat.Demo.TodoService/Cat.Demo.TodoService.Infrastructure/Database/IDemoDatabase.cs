using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.TodoService.DataModels.Entities;

namespace Cat.Demo.TodoService.Infrastructure.Database;

public interface IDemoDatabase
{
    Task<IList<Todo>> GetTodoListAsync(Guid? todoCategoryId, CancellationToken cancellationToken = default);
    Task<Todo?> GetTodoAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> SaveAsync(Todo todo, CancellationToken cancellationToken = default);
}
