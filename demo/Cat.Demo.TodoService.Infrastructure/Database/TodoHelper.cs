using Cat.Demo.TodoService.Models.Entities;

namespace Cat.Demo.TodoService.Infrastructure.Database;

internal static class TodoHelper
{
    internal static Todo Todo1 => new Todo { Id = 1, CategoryId = 1, Title = "Todo 1", Description = "Description for todo 1." };
    internal static Todo Todo2 => new Todo { Id = 2, CategoryId = 1, Title = "Todo 2", Description = "Description for todo 2."};
    internal static Todo Todo3 => new Todo { Id = 3, CategoryId = 2, Title = "Todo 3", Description = "Description for todo 3."};
    internal static Todo Todo4 => new Todo { Id = 4, CategoryId = 2, Title = "Todo 4", Description = "Description for todo 4."};
}