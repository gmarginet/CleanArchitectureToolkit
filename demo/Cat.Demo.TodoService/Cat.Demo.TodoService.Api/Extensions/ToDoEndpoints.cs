using System.Collections.Generic;
using Cat.Demo.TodoService.Contracts.Models;
using Cat.Demo.TodoService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.TodoService.Api.Extensions;

public static class ToDoEndpoints
{
    public static IEndpointRouteBuilder MapToDoServiceEndpoints(this IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("/todo");

        groupBuilder.MapCatGetList<TodoGetListRequest, TodoModel>("/");
        groupBuilder.MapCatGet<TodoGetRequest, TodoModel>("/{todoId:int}", CatResponseType.Ok, CatResponseType.NotFound);
        groupBuilder.MapCatPost<TodoSaveRequest>("/", CatResponseType.Ok);

        return builder;
    }
}
