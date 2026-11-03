using Cat.Demo.TodoService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.ToDoService.Core.Queries;

public record TodoGetQuery(int? TodoId) : ICatQuery<Todo>;