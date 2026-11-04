using System;
using System.Collections.Generic;
using Cat.Demo.TodoService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.ToDoService.Core.Queries;

public record TodoGetListQuery(Guid? TodoCategoryId) : ICatQuery<IList<Todo>>;
