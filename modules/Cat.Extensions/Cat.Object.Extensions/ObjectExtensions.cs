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
    /// Returns the value once confirmed to be at least <paramref name="minimum"/>, otherwise throws.
    /// </summary>
    /// <typeparam name="T">The type being compared. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minimum">The lowest value that is allowed.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be at least <paramref name="minimum"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't implement <see cref="IComparable{T}"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is less than <paramref name="minimum"/>.</exception>
    public static T ThrowIfLessThan<T>(this T value, T minimum, string paramName)
        => CompareDefault(value, minimum) < 0
            ? throw new ArgumentOutOfRangeException(paramName, value, $"{paramName} must be {minimum} or higher.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be at least <paramref name="minimum"/>, otherwise throws. Uses the given comparer.
    /// </summary>
    /// <typeparam name="T">The type being compared.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minimum">The lowest value that is allowed.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be at least <paramref name="minimum"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is less than <paramref name="minimum"/>.</exception>
    public static T ThrowIfLessThan<T>(this T value, T minimum, IComparer<T> comparer, string paramName)
        => comparer.Compare(value, minimum) < 0
            ? throw new ArgumentOutOfRangeException(paramName, value, $"{paramName} must be {minimum} or higher.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be higher than <paramref name="limit"/>, otherwise throws.
    /// </summary>
    /// <typeparam name="T">The type being compared. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="limit">The value that <paramref name="value"/> must be higher than.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be higher than <paramref name="limit"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't implement <see cref="IComparable{T}"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is less than or equal to <paramref name="limit"/>.</exception>
    public static T ThrowIfLessThanOrEqualTo<T>(this T value, T limit, string paramName)
        => CompareDefault(value, limit) <= 0
            ? throw new ArgumentOutOfRangeException(paramName, value, $"{paramName} must be higher than {limit}.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be higher than <paramref name="limit"/>, otherwise throws. Uses the given comparer.
    /// </summary>
    /// <typeparam name="T">The type being compared.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="limit">The value that <paramref name="value"/> must be higher than.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be higher than <paramref name="limit"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is less than or equal to <paramref name="limit"/>.</exception>
    public static T ThrowIfLessThanOrEqualTo<T>(this T value, T limit, IComparer<T> comparer, string paramName)
        => comparer.Compare(value, limit) <= 0
            ? throw new ArgumentOutOfRangeException(paramName, value, $"{paramName} must be higher than {limit}.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be at most <paramref name="maximum"/>, otherwise throws.
    /// </summary>
    /// <typeparam name="T">The type being compared. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="maximum">The highest value that is allowed.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be at most <paramref name="maximum"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't implement <see cref="IComparable{T}"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is greater than <paramref name="maximum"/>.</exception>
    public static T ThrowIfGreaterThan<T>(this T value, T maximum, string paramName)
        => CompareDefault(value, maximum) > 0
            ? throw new ArgumentOutOfRangeException(paramName, value, $"{paramName} must be {maximum} or lower.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be at most <paramref name="maximum"/>, otherwise throws. Uses the given comparer.
    /// </summary>
    /// <typeparam name="T">The type being compared.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="maximum">The highest value that is allowed.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="paramName">The name of the parameter to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be at most <paramref name="maximum"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is greater than <paramref name="maximum"/>.</exception>
    public static T ThrowIfGreaterThan<T>(this T value, T maximum, IComparer<T> comparer, string paramName)
        => comparer.Compare(value, maximum) > 0
            ? throw new ArgumentOutOfRangeException(paramName, value, $"{paramName} must be {maximum} or lower.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be less than <paramref name="limit"/>, otherwise throws.
    /// </summary>
    /// <typeparam name="T">The type being compared. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="limit">The value that <paramref name="value"/> must be less than.</param>
    /// <param name="valueName">The name of <paramref name="value"/> to report in the exception.</param>
    /// <param name="limitName">The name of <paramref name="limit"/> to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be less than <paramref name="limit"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't implement <see cref="IComparable{T}"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is greater than or equal to <paramref name="limit"/>.</exception>
    public static T ThrowIfGreaterThanOrEqualTo<T>(this T value, T limit, string valueName, string limitName)
        => CompareDefault(value, limit) >= 0
            ? throw new ArgumentOutOfRangeException(valueName, value, $"{valueName} must be less than {limitName}.")
            : value;

    /// <summary>
    /// Returns the value once confirmed to be less than <paramref name="limit"/>, otherwise throws. Uses the given comparer.
    /// </summary>
    /// <typeparam name="T">The type being compared.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="limit">The value that <paramref name="value"/> must be less than.</param>
    /// <param name="comparer">The comparer to use.</param>
    /// <param name="valueName">The name of <paramref name="value"/> to report in the exception.</param>
    /// <param name="limitName">The name of <paramref name="limit"/> to report in the exception.</param>
    /// <returns><paramref name="value"/>, once confirmed to be less than <paramref name="limit"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is greater than or equal to <paramref name="limit"/>.</exception>
    public static T ThrowIfGreaterThanOrEqualTo<T>(this T value, T limit, IComparer<T> comparer, string valueName, string limitName)
        => comparer.Compare(value, limit) >= 0
            ? throw new ArgumentOutOfRangeException(valueName, value, $"{valueName} must be less than {limitName}.")
            : value;

    /// <summary>
    /// Compares two values using <typeparamref name="T"/>'s default comparison.
    /// </summary>
    /// <typeparam name="T">The type being compared. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="value">The value to compare.</param>
    /// <param name="other">The value to compare with.</param>
    /// <returns>A negative number when <paramref name="value"/> is lower, zero when they are equal, a positive number when it is higher.</returns>
    /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't implement <see cref="IComparable{T}"/>.</exception>
    private static int CompareDefault<T>(T value, T other)
        => value is IComparable<T> comparable
            ? comparable.CompareTo(other)
            : throw new ArgumentException("T is not IComparable<T>", nameof(value));
}
