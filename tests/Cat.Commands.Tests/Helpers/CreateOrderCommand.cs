using Cat.Commands.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Commands.Tests.Helpers;

public record OrderCreated(Guid OrderId, int OrderNumber);

public record CreateOrderCommand(Guid OrderId, string Customer) : ICatCommand<OrderCreated>;

public record UnhandledResultCommand : ICatCommand<OrderCreated>;

public class CreateOrderCommandHandler : ICatCommandHandler<CreateOrderCommand, OrderCreated>
{
    private readonly CommandRecorder _recorder;
    private readonly ScopedMarker _marker;

    public CreateOrderCommandHandler(CommandRecorder recorder, ScopedMarker marker)
    {
        _recorder = recorder;
        _marker = marker;
    }

    public Task<ICatResponse<OrderCreated>> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        _recorder.Add(command.Customer, _marker.Id, cancellationToken);

        return command.Customer switch
        {
            "fail" => Task.FromResult<ICatResponse<OrderCreated>>(CatResponse.BadRequest<OrderCreated>(
                CatError.Create("ORD-1", "Customer {name} is not allowed", command.Customer))),
            "throw" => throw new InvalidOperationException("boom"),
            _ => Task.FromResult<ICatResponse<OrderCreated>>(CatResponse.Ok(new OrderCreated(command.OrderId, 42)))
        };
    }
}
