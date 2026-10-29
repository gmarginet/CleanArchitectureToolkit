namespace Cat.Demo.TodoService.Events.Models;

public class TodoModel
{
    public int? Id { get; set; }
    public int? CategoryId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}