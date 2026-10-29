namespace Cat.Decorators.Tests.Helpers;

public interface IHandler<T>
{
    string Handle(T input);
}

public class Handler<T> : IHandler<T>
{
    public string Handle(T input) => "handled:" + input;
}

public interface IClock
{
    string Now { get; }
}

public class FixedClock : IClock
{
    public string Now => "12:00";
}

public class UpperDecorator<T> : IHandler<T>
{
    private readonly IHandler<T> _inner;

    public UpperDecorator(IHandler<T> inner)
    {
        _inner = inner;
    }

    public string Handle(T input) => _inner.Handle(input).ToUpperInvariant();
}

public class BracketDecorator<T> : IHandler<T>
{
    private readonly IHandler<T> _inner;

    public BracketDecorator(IHandler<T> inner)
    {
        _inner = inner;
    }

    public string Handle(T input) => "[" + _inner.Handle(input) + "]";
}

public class PrefixDecorator<T> : IHandler<T>
{
    private readonly IHandler<T> _inner;
    private readonly string _prefix;

    public PrefixDecorator(IHandler<T> inner, string prefix)
    {
        _inner = inner;
        _prefix = prefix;
    }

    public string Handle(T input) => _prefix + _inner.Handle(input);
}

public class ClockDecorator<T> : IHandler<T>
{
    private readonly IHandler<T> _inner;
    private readonly IClock _clock;

    public ClockDecorator(IHandler<T> inner, IClock clock)
    {
        _inner = inner;
        _clock = clock;
    }

    public string Handle(T input) => _clock.Now + " " + _inner.Handle(input);
}

public class TwoConstructorsDecorator<T> : IHandler<T>
{
    private readonly IHandler<T> _inner;

    public TwoConstructorsDecorator(IHandler<T> inner)
    {
        _inner = inner;
    }

    public TwoConstructorsDecorator(IHandler<T> inner, string extra)
    {
        _inner = inner;
    }

    public string Handle(T input) => _inner.Handle(input);
}

public class NotGenericHandlerDecorator : IHandler<string>
{
    public string Handle(string input) => input;
}
