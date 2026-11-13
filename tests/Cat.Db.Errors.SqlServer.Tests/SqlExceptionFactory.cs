using System.Reflection;
using Microsoft.Data.SqlClient;

namespace Cat.Db.Errors.SqlServer.Tests;

/// <summary>
/// Builds a <see cref="SqlException"/> with a given error number. SqlClient has no public constructor for it,
/// so this reaches the internal members with reflection.
/// </summary>
internal static class SqlExceptionFactory
{
    private const BindingFlags NonPublic = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;

    public static SqlException Create(int number)
    {
        var errorConstructor = typeof(SqlError)
            .GetConstructors(NonPublic)
            .OrderByDescending(c => c.GetParameters().Length)
            .First();
        var error = errorConstructor.Invoke(Fill(errorConstructor.GetParameters(), number));

        var collectionType = typeof(SqlErrorCollection);
        var collectionConstructor = collectionType.GetConstructors(NonPublic).First();
        var collection = collectionConstructor.Invoke(Fill(collectionConstructor.GetParameters(), 0));
        collectionType.GetMethod("Add", NonPublic)!.Invoke(collection, new[] { error });

        var factory = typeof(SqlException)
            .GetMethods(NonPublic)
            .Where(m => m.Name == "CreateException" && m.IsStatic)
            .OrderBy(m => m.GetParameters().Length)
            .First(m => m.GetParameters().Any(p => p.ParameterType == collectionType));
        var args = factory.GetParameters()
            .Select(p => p.ParameterType == collectionType ? collection : DefaultFor(p.ParameterType))
            .ToArray();
        return (SqlException)factory.Invoke(null, args)!;
    }

    private static object?[] Fill(ParameterInfo[] parameters, int number)
    {
        var firstInt = true;
        return parameters.Select(p =>
        {
            if (p.ParameterType == typeof(int) && firstInt) { firstInt = false; return (object)number; }
            return DefaultFor(p.ParameterType);
        }).ToArray();
    }

    private static object? DefaultFor(Type type)
    {
        if (type == typeof(string)) return "";
        if (type.IsValueType) return Activator.CreateInstance(type);
        return null;
    }
}
