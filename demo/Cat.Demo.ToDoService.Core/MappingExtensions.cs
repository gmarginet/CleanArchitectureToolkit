using Cat.Demo.ToDoService.Core.Commands;
using Cat.Demo.ToDoService.Core.Queries;
using Cat.Demo.TodoService.Events.Models;
using Cat.Demo.TodoService.Events.ServiceRequests;
using Cat.Demo.TodoService.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace Cat.Demo.ToDoService.Core;

[Mapper(UseDeepCloning = true)]
public static partial class MappingExtensions
{
    public static partial TodoGetQuery ToQuery(this TodoGetRequest request);
    public static partial TodoGetListQuery ToQuery(this TodoGetListRequest request);

    public static partial TodoSaveCommand ToCommand(this TodoSaveRequest request);
    
    public static partial TodoModel ToModel(this Todo model);
}
