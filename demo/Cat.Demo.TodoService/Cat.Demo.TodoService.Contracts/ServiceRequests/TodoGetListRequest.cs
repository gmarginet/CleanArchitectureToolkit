using System.Collections.Generic;
using Cat.Demo.TodoService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.TodoService.Contracts.ServiceRequests;

public record TodoGetListRequest(int? TodoCategoryId) : ICatServiceRequest<IList<TodoModel>>;