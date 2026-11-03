using Cat.EFCore.Entities;

namespace Cat.Demo.TodoService.DataModels.Entities;

public class Category : CatEntityBase
{
    public required string Name { get; set; }
}
