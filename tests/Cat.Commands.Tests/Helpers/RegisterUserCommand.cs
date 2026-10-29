using Cat.Commands.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Commands.Tests.Helpers;

public record RegisterUserCommand(string Name) : ICatCommand;

public record UnhandledCommand : ICatCommand;

/// <summary>
/// Remembers what the handler saw. It is a singleton, so it outlives the scope of a call.
/// </summary>
public class CommandRecorder
{
    private readonly object _lock = new();

    public List<(string Name, Guid ScopeId, CancellationToken Token)> Calls { get; } = [];

    public void Add(string name, Guid scopeId, CancellationToken token)
    {
        lock (_lock) Calls.Add((name, scopeId, token));
    }
}

/// <summary>
/// A scoped service. Every scope gets its own id.
/// </summary>
public class ScopedMarker
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class RegisterUserCommandHandler : ICatCommandHandler<RegisterUserCommand>
{
    private readonly CommandRecorder _recorder;
    private readonly ScopedMarker _marker;

    public RegisterUserCommandHandler(CommandRecorder recorder, ScopedMarker marker)
    {
        _recorder = recorder;
        _marker = marker;
    }

    public Task<ICatResponse> HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        _recorder.Add(command.Name, _marker.Id, cancellationToken);

        return command.Name switch
        {
            "fail" => Task.FromResult<ICatResponse>(CatResponse.BadRequest(
                CatError.Create("USR-1", "Name {name} is not allowed", command.Name),
                CatError.Create("USR-2", "Second problem"))),
            "throw" => throw new InvalidOperationException("boom"),
            _ => Task.FromResult<ICatResponse>(CatResponse.Ok())
        };
    }
}

/// <summary>
/// A generic handler. The module skips generic handlers when it scans.
/// </summary>
public class GenericCommandHandler<T> : ICatCommandHandler<RegisterUserCommand>
{
    public Task<ICatResponse> HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse>(CatResponse.Ok());
    }
}
