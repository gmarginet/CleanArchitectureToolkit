using Cat.Commands.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Tests;

/// <summary>
/// A command processor for tests. It records the commands and returns a set response.
/// </summary>
public class FakeCommandProcessor : ICatCommandProcessor
{
    /// <summary>The response every command gets.</summary>
    public ICatResponse Response { get; set; } = CatResponse.Ok();

    /// <summary>Every command that was processed, in order.</summary>
    public List<ICatCommand> Commands { get; } = [];

    public Task<ICatResponse> ProcessAsync(ICatCommand catCommand, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Process(catCommand));
    }

    public ICatResponse Process(ICatCommand catCommand)
    {
        Commands.Add(catCommand);
        return Response;
    }
}
