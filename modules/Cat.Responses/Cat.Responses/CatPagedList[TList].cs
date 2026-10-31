using System.Collections.Generic;
using System.Linq;
using Cat.Object.Extensions;
using Cat.Responses.Abstractions;

namespace Cat.Responses;

/// <summary>
/// The default <see cref="ICatPagedList{TList}"/> implementation. Every value is checked when it is set,
/// and two pages are equal when their numbers and items are equal.
/// </summary>
/// <typeparam name="TList">The type of the items in the page.</typeparam>
public record CatPagedList<TList> : ICatPagedList<TList>
{
    /// <summary>
    /// Creates a page from the given values.
    /// </summary>
    /// <param name="list">The items on this page.</param>
    /// <param name="pageNumber">The number of this page. The first page is 1.</param>
    /// <param name="pageSize">The maximum number of items on a page.</param>
    /// <param name="totalItemCount">The number of items across all pages.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="list"/> is <c>null</c>.</exception>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber"/> or <paramref name="pageSize"/> is less than 1, or <paramref name="totalItemCount"/> is negative.</exception>
    public CatPagedList(
        IReadOnlyList<TList> list,
        int pageNumber,
        int pageSize,
        int totalItemCount)
    {
        List = list;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItemCount = totalItemCount;
    }

    /// <inheritdoc />
    /// <exception cref="System.ArgumentNullException">Thrown when set to <c>null</c>.</exception>
    public IReadOnlyList<TList> List
    {
        get;
        init => field = value.ThrowIfNull(nameof(List));
    }

    /// <inheritdoc />
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when set to less than 1.</exception>
    public int PageNumber
    {
        get;
        init => field = value.ThrowIfLessThan(1, nameof(PageNumber));
    }

    /// <inheritdoc />
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when set to less than 1.</exception>
    public int PageSize
    {
        get;
        init => field = value.ThrowIfLessThan(1, nameof(PageSize));
    }

    /// <inheritdoc />
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown when set to a negative number.</exception>
    public int TotalItemCount
    {
        get;
        init => field = value.ThrowIfLessThan(0, nameof(TotalItemCount));
    }

    /// <inheritdoc />
    public int TotalPages => (int)(((long)TotalItemCount + PageSize - 1) / PageSize);

    /// <summary>
    /// Checks whether another page has the same numbers and the same items in the same order.
    /// </summary>
    /// <param name="other">The page to compare with.</param>
    /// <returns><c>true</c> when both pages are equal, otherwise <c>false</c>.</returns>
    public virtual bool Equals(CatPagedList<TList>? other)
    {
        if (ReferenceEquals(this, other)) return true;

        return other is not null
               && EqualityContract == other.EqualityContract
               && PageNumber == other.PageNumber
               && PageSize == other.PageSize
               && TotalItemCount == other.TotalItemCount
               && List.SequenceEqual(other.List);
    }

    /// <summary>
    /// Builds a hash code from the numbers and every item on the page.
    /// </summary>
    /// <returns>The hash code. It changes when the items in a mutable list change.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 31 + PageNumber;
            hash = hash * 31 + PageSize;
            hash = hash * 31 + TotalItemCount;
            foreach (var item in List) hash = hash * 31 + (item?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
