using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.Queries;

/// <summary>
/// Paging for Entity Framework Core queries.
/// </summary>
public static class QueryablePagingExtensions
{
    /// <summary>
    /// Counts all items, then reads one page of them. Sort the query before you call this,
    /// otherwise the pages have no stable order.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    /// <param name="source">The sorted and filtered query.</param>
    /// <param name="pageNumber">The number of the page to read. The first page is 1.</param>
    /// <param name="pageSize">The maximum number of items on a page.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The page, with the total item count of the whole query.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber"/> or <paramref name="pageSize"/> is less than 1.</exception>
    public static async Task<ICatPagedList<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber));
        if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

        var total = await source.CountAsync(cancellationToken);

        // A page far past the end gives an empty page. The long keeps a huge page number from overflowing.
        var skip = (int)Math.Min((long)(pageNumber - 1) * pageSize, int.MaxValue);
        var items = await source
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new CatPagedList<T>(items, pageNumber, pageSize, total);
    }
}
