using Cat.Demo.TodoService.Models.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.ToDoService.Core.Queries;

public record TodoGetQuery(int? TodoId) : ICatQuery<Todo>;