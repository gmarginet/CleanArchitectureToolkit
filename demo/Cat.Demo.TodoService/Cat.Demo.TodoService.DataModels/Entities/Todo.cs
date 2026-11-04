using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.TodoService.DataModels.Entities;

public class Todo : CatTemporalEntityBase
{
    public Guid CategoryId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
