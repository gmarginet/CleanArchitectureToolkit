namespace Cat.Demo.TodoService.Models.Entities;

public class Todo
{
    public int? Id { get; set; }
    public int? CategoryId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}