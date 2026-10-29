using Cat.Commands.Abstractions;
using Cat.Demo.TodoService.Models.Entities;

namespace Cat.Demo.ToDoService.Core.Commands;

public record TodoSaveCommand(Todo Todo) : ICatCommand;