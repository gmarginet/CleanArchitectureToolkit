using System;

namespace Cat.Demo.TodoService.Contracts.Models;

public class TodoModel
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
