using System;
using System.Collections.Generic;

namespace Cat.Caching.Abstractions;

/// <summary>
/// The settings of one cache entry. The expiry is absolute. There is no sliding expiry.
/// </summary>
public sealed class CatQueryCacheEntryOptions
{
    /// <summary>
    /// How long the entry lives, counted from the moment it is stored.
    /// </summary>
    public TimeSpan Expiration { get; set; }

    /// <summary>
    /// How long the memory level of the cache keeps the entry. Empty means the same as <see cref="Expiration"/>.
    /// A short value bounds how long another instance serves an entry that was removed by its tag.
    /// </summary>
    public TimeSpan? LocalExpiration { get; set; }

    /// <summary>
    /// The tags of the entry. <see cref="ICatQueryCache.RemoveByTagAsync"/> removes the entries of a tag.
    /// </summary>
    public IReadOnlyCollection<string> Tags { get; set; } = Array.Empty<string>();
}
