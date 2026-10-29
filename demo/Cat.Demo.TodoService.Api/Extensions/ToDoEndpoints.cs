using System.Collections.Generic;
using Cat.Demo.TodoService.Events.Models;
using Cat.Demo.TodoService.Events.ServiceRequests;
using Cat.Minimal.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.TodoService.Api.Extensions;

public static class ToDoEndpoints
{
    public static IEndpointRouteBuilder MapToDoServiceEndpoints(this IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("/todo");

        groupBuilder.MapCatServiceRequest<TodoGetListRequest, IList<TodoModel>>("/list");
        groupBuilder.MapCatServiceRequest<TodoGetRequest, TodoModel>("/get");
        groupBuilder.MapCatServiceRequest<TodoSaveRequest>("/create-update");
            
        return builder;
    }
}







