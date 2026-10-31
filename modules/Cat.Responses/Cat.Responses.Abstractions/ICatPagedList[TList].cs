using System.Collections.Generic;

namespace Cat.Responses.Abstractions;

/// <summary>
/// One page of a larger list, with the numbers needed to page through the rest.
/// </summary>
/// <typeparam name="TList">The type of the items in the page.</typeparam>
public interface ICatPagedList<TList>
{
    /// <summary>
    /// The items on this page.
    /// </summary>
    public IReadOnlyList<TList> List { get; }

    /// <summary>
    /// The number of this page. The first page is 1.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    /// The maximum number of items on a page.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// The number of items across all pages.
    /// </summary>
    public int TotalItemCount { get; }

    /// <summary>
    /// The number of pages needed to hold all items.
    /// </summary>
    public int TotalPages { get; }
}
