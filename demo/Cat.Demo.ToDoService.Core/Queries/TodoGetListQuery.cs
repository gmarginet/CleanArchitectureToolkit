using System.Collections.Generic;
using Cat.Demo.TodoService.Models.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.ToDoService.Core.Queries;

public record TodoGetListQuery(int? TodoCategoryId) : ICatQuery<IList<Todo>>;