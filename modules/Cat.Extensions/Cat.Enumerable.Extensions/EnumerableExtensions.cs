using System;
using System.Collections;

namespace Cat.Enumerable.Extensions;

/// <summary>
/// Extension methods for <see cref="IEnumerable"/>.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Checks whether the sequence has no elements.
    /// </summary>
    /// <param name="enumerable">The sequence to check.</param>
    /// <returns><c>true</c> if the sequence has no elements, otherwise <c>false</c>.</returns>
    public static bool IsEmpty(this IEnumerable enumerable)
    {
        var enumerator = enumerable.GetEnumerator();

        using (enumerator as IDisposable) {
            return !enumerator.MoveNext();
        }
    }
}