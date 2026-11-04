using Cat.Demo.TodoService.DataModels.Entities;

namespace Cat.Demo.TodoService.Infrastructure.Database;

internal static class TodoHelper
{
    internal static Todo Todo1 => new Todo { CategoryId = Category1.Id, Title = "Todo 1", Description = "Description for todo 1." };
    internal static Todo Todo2 => new Todo { CategoryId = Category1.Id, Title = "Todo 2"};
    internal static Todo Todo3 => new Todo { CategoryId = Category2.Id, Title = "Todo 3", Description = "Description for todo 3."};
    internal static Todo Todo4 => new Todo { CategoryId = Category2.Id, Title = "Todo 4"};
    
    internal static Category Category1 => new Category { Name = "Category 1" };
    internal static Category Category2 => new Category { Name = "Category 2" };
}
