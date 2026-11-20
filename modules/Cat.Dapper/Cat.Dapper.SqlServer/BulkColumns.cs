using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cat.Dapper.SqlServer;

/// <summary>
/// One column of a bulk call: its name, the type of its values and how to read it from a row.
/// </summary>
internal sealed class BulkColumn
{
    internal BulkColumn(string name, Type fieldType, Func<object, object?> getter)
    {
        Name = name;
        FieldType = fieldType;
        Getter = getter;
    }

    internal string Name { get; }

    internal Type FieldType { get; }

    internal Func<object, object?> Getter { get; }
}

/// <summary>
/// Finds the columns of a row class by reflection, once per type, and keeps them.
/// </summary>
internal static class BulkColumns
{
    private static readonly ConcurrentDictionary<Type, IReadOnlyList<BulkColumn>> Cache = new();

    /// <summary>
    /// All public readable instance properties of the type, in declaration order.
    /// </summary>
    internal static IReadOnlyList<BulkColumn> ForType(Type type) => Cache.GetOrAdd(type, Build);

    /// <summary>
    /// The columns with the given names, in the order of the names. All columns when <paramref name="names"/> is <c>null</c>.
    /// The names match a property name without regard to case.
    /// </summary>
    internal static IReadOnlyList<BulkColumn> Select(Type type, IEnumerable<string>? names, string parameterName)
    {
        var all = ForType(type);
        if (names is null) return all;

        var list = new List<BulkColumn>();
        foreach (var name in names)
        {
            if (name is null) throw new ArgumentException("A column name is null.", parameterName);
            var column = all.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
            if (column is null) throw new ArgumentException($"The type {type.Name} has no property for the column '{name}'.", parameterName);
            if (list.Contains(column)) throw new ArgumentException($"The column '{name}' is given twice.", parameterName);
            list.Add(column);
        }

        if (list.Count == 0) throw new ArgumentException("The list of columns is empty.", parameterName);
        return list;
    }

    private static IReadOnlyList<BulkColumn> Build(Type type)
    {
        var columns = type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
            .Select(p => Create(type, p))
            .ToList();

        if (columns.Count == 0) throw new ArgumentException($"The type {type.Name} has no public readable properties.");
        return columns;
    }

    private static BulkColumn Create(Type type, PropertyInfo property)
    {
        var fieldType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        if (fieldType.IsEnum) fieldType = Enum.GetUnderlyingType(fieldType);

        var row = Expression.Parameter(typeof(object), "row");
        Expression value = Expression.Property(Expression.Convert(row, type), property);

        var propertyType = property.PropertyType;
        var plainType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
        if (plainType.IsEnum)
        {
            var target = Nullable.GetUnderlyingType(propertyType) is null ? fieldType : typeof(Nullable<>).MakeGenericType(fieldType);
            value = Expression.Convert(value, target);
        }

        var getter = Expression.Lambda<Func<object, object?>>(Expression.Convert(value, typeof(object)), row).Compile();
        return new BulkColumn(property.Name, fieldType, getter);
    }
}
