using Cat.Demo.TodoService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.TodoService.Contracts.ServiceRequests;

public record TodoGetRequest(int? TodoId) : ICatServiceRequest<TodoModel>;