using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.ToDoService.Core.Commands;
using Cat.Demo.TodoService.Infrastructure.Database;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.TodoService.Infrastructure.CommandHandlers;

public class TodoSaveCommandHandler : ICatCommandHandler<TodoSaveCommand>
{
    private readonly IDemoDatabase _demoDatabase;

    public TodoSaveCommandHandler(IDemoDatabase demoDatabase)
    {
        _demoDatabase = demoDatabase;
    }

    public async Task<ICatResponse> HandleAsync(TodoSaveCommand command, CancellationToken cancellationToken = default)
    {
        command.Todo.ThrowIfNull(nameof(command.Todo));

        await _demoDatabase.SaveAsync(command.Todo, cancellationToken);
        return CatResponse.Ok();
    }
}