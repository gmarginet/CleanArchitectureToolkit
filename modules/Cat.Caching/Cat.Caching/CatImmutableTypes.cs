using System;
using System.ComponentModel;
using System.Reflection;

namespace Cat.Caching;

/// <summary>
/// Tells whether <c>HybridCache</c> sees a type as immutable: a <c>string</c>, a value type, or a sealed class marked with
/// <c>[ImmutableObject(true)]</c>. Every other type is mutable, and <c>HybridCache</c> hands out a copy on every hit.
/// The module follows that rule and adds no copy logic of its own.
/// </summary>
internal static class CatImmutableTypes
{
    public static bool IsImmutable(Type type)
    {
        if (type == typeof(string) || type.IsValueType)
        {
            return true;
        }

        return type.IsSealed && type.GetCustomAttribute<ImmutableObjectAttribute>()?.Immutable == true;
    }
}
