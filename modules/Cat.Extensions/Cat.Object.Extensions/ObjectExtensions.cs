using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cat.Object.Extensions;

/// <summary>
/// Extension methods for argument validation.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Returns the argument once confirmed non-null, otherwise throws.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    /// <param name="argument">The argument to check.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="argument"/>, once confirmed non-null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="argument"/> is <c>null</c>.</exception>
    public static T ThrowIfNull<T>([NotNull] this T? argument, string paramName)
        => argument ?? throw new ArgumentNullException(paramName);

    /// <summary>
    /// Throws if <paramref name="lowerBound"/> is greater than or equal to <paramref name="upperBound"/>, using <typeparamref name="T"/>'s default comparison.
    /// </summary>
    /// <typeparam name="T">The type being compared. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="lowerBound">The value expected to be the lower bound.</param>
    /// <param name="upperBound">The value expected to be the upper bound.</param>
    /// <param name="lowerBoundName">The name of the lower bound to report in the exception.</param>
    /// <param name="upperBoundName">The name of the upper bound to report in the exception.</param>
    /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't implement <see cref="IComparable{T}"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="lowerBound"/> is greater than or equal to <paramref name="upperBound"/>.</exception>
    public static void ThrowIfGreaterThanOrEqualTo<T>(this T lowerBound, T upperBound, string lowerBoundName, string upperBoundName)
    {
        if (lowerBound is not IComparable<T> comparableLowerBound) throw new ArgumentException("TProperty is not IComparable<TProperty>", nameof(lowerBound));
        if (upperBound is not IComparable<T> comparableUpperBound) throw new ArgumentException("TProperty is not IComparable<TProperty>", nameof(upperBound));
        if (comparableLowerBound.CompareTo(upperBound) >= 0) throw new ArgumentOutOfRangeException($"{lowerBoundName} must be less than {upperBoundName}.");
    }

    /// <summary>
    /// Throws if <paramref name="lowerBound"/> is greater than or equal to <paramref name="upperBound"/>, using the given comparer.
    /// </summary>
    /// <typeparam name="T">The type being compared.</typeparam>
    /// <param name="lowerBound">The value expected to be the lower bound.</param>
    /// <param name="upperBound">The value expected to be the upper bound.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="lowerBoundName">The name of the lower bound to report in the exception.</param>
    /// <param name="upperBoundName">The name of the upper bound to report in the exception.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="lowerBound"/> is greater than or equal to <paramref name="upperBound"/>.</exception>
    public static void ThrowIfGreaterThanOrEqualTo<T>(this T lowerBound, T upperBound, IComparer<T> comparer,
        string lowerBoundName, string upperBoundName)
    {
        if (comparer.Compare(lowerBound, upperBound) >= 0)
            throw new ArgumentOutOfRangeException($"{lowerBoundName} must be less than {upperBoundName}.");
    }
}