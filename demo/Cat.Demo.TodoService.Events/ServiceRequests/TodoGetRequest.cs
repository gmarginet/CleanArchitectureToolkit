using Cat.Demo.TodoService.Events.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.TodoService.Events.ServiceRequests;

public record TodoGetRequest(int? TodoId) : ICatServiceRequest<TodoModel>;