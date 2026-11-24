using System.Collections.Generic;
using System.Linq;

namespace Cat.Validators.Rules;

/// <summary>
/// Reads a text property as a string, for the string rules. They accept <c>string</c> and <c>string?</c> properties.
/// </summary>
internal static class PropertyTextExtensions
{
    /// <summary>
    /// Returns the property as a string. A <c>null</c> property gives <c>null</c>.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property, a string or a sequence of characters.</typeparam>
    /// <param name="property">The property value.</param>
    /// <returns>The text, or <c>null</c> when the property is <c>null</c>.</returns>
    public static string? AsText<TProperty>(this TProperty property)
        where TProperty : IEnumerable<char>?
    {
        if (property is null) return null;

        return property as string ?? new string(property.ToArray());
    }
}
