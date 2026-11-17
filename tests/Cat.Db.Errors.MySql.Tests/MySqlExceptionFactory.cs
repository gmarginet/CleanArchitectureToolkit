using System.Reflection;
using MySqlConnector;

namespace Cat.Db.Errors.MySql.Tests;

/// <summary>
/// Builds a <see cref="MySqlException"/> with a given error number. MySqlConnector has no public constructor
/// that takes an error code, so this reaches a non public one with reflection.
/// </summary>
internal static class MySqlExceptionFactory
{
    private const BindingFlags AnyConstructor = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    public static MySqlException Create(int number)
    {
        var constructor = typeof(MySqlException)
            .GetConstructors(AnyConstructor)
            .Where(c => c.GetParameters().Any(p => p.ParameterType == typeof(MySqlErrorCode)))
            .OrderBy(c => c.GetParameters().Length)
            .First();
        var arguments = constructor.GetParameters().Select(p => Argument(p.ParameterType, number)).ToArray();
        return (MySqlException)constructor.Invoke(arguments);
    }

    private static object? Argument(Type type, int number)
    {
        if (type == typeof(MySqlErrorCode)) return (MySqlErrorCode)number;
        if (type == typeof(string)) return "test";
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
