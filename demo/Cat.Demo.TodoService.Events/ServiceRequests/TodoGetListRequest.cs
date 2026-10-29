using System.Collections.Generic;
using Cat.Demo.TodoService.Events.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.TodoService.Events.ServiceRequests;

public record TodoGetListRequest(int? TodoCategoryId) : ICatServiceRequest<IList<TodoModel>>;