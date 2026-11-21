using System;
using System.Collections.Generic;
using System.Linq;

namespace Cat.Caching.Abstractions;

/// <summary>
/// The settings of one cached query type. Read them through <see cref="CatQueryCacheOptions.Rules"/>.
/// </summary>
public class CatQueryCacheRule
{
    private readonly List<string> _tags = new List<string>();

    /// <summary>
    /// How long an entry lives. Empty means <see cref="CatQueryCacheOptions.DefaultExpiration"/>.
    /// </summary>
    public TimeSpan? Expiration { get; protected set; }

    /// <summary>
    /// How long the memory level keeps an entry. Empty means the same as <see cref="Expiration"/>.
    /// </summary>
    public TimeSpan? LocalExpiration { get; protected set; }

    /// <summary>
    /// The tags of the entries of this query type.
    /// </summary>
    public IReadOnlyCollection<string> Tags => _tags;

    /// <summary>
    /// True when every user shares one entry. The default is false: the key holds the user, so one user never gets the entry of another.
    /// </summary>
    public bool IsShared { get; protected set; }

    /// <summary>
    /// How long a <c>NotFound</c> response is kept. Empty means a <c>NotFound</c> is not cached.
    /// </summary>
    public TimeSpan? NotFoundExpiration { get; protected set; }

    /// <summary>
    /// Builds the part of the key that comes from the query, instead of the serialized query. Empty means the default.
    /// </summary>
    public Func<object, string>? KeyFunction { get; protected set; }

    /// <summary>
    /// Adds tags to the entries of this query type.
    /// </summary>
    /// <param name="tags">The tags, for example <c>"books"</c>.</param>
    /// <exception cref="ArgumentException">A tag is empty.</exception>
    protected void AddTags(IEnumerable<string> tags)
    {
        foreach (var tag in tags)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentException("A tag cannot be empty.", nameof(tags));
            }

            if (!_tags.Contains(tag))
            {
                _tags.Add(tag);
            }
        }
    }

    /// <summary>
    /// Checks that a lifetime is more than zero.
    /// </summary>
    /// <param name="lifetime">The lifetime to check.</param>
    /// <param name="name">The name of the argument.</param>
    /// <exception cref="ArgumentOutOfRangeException">The lifetime is zero or less.</exception>
    protected static void RequirePositive(TimeSpan lifetime, string name)
    {
        if (lifetime <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(name, "A lifetime must be more than zero.");
        }
    }
}

/// <summary>
/// The settings of one cached query type, set in a fluent way in <see cref="CatQueryCacheOptions.Cache{TQuery}"/>.
/// </summary>
/// <typeparam name="TQuery">The query type.</typeparam>
public sealed class CatQueryCacheRule<TQuery> : CatQueryCacheRule
    where TQuery : class
{
    /// <summary>
    /// Sets how long an entry lives. The expiry is absolute.
    /// </summary>
    /// <param name="lifetime">The lifetime, more than zero.</param>
    /// <returns>The same rule, for chaining.</returns>
    public CatQueryCacheRule<TQuery> Expires(TimeSpan lifetime)
    {
        RequirePositive(lifetime, nameof(lifetime));
        Expiration = lifetime;
        return this;
    }

    /// <summary>
    /// Sets how long the memory level keeps an entry. A shorter time bounds how long another instance serves an entry that was removed by its tag.
    /// </summary>
    /// <param name="lifetime">The lifetime, more than zero.</param>
    /// <returns>The same rule, for chaining.</returns>
    public CatQueryCacheRule<TQuery> ExpiresLocally(TimeSpan lifetime)
    {
        RequirePositive(lifetime, nameof(lifetime));
        LocalExpiration = lifetime;
        return this;
    }

    /// <summary>
    /// Gives the entries of this query type one or more tags. A command or an event subscriber clears them with <see cref="ICatQueryCache.RemoveByTagAsync"/>.
    /// </summary>
    /// <param name="tags">The tags, for example <c>"books"</c>.</param>
    /// <returns>The same rule, for chaining.</returns>
    public CatQueryCacheRule<TQuery> Tag(params string[] tags)
    {
        AddTags(tags ?? Array.Empty<string>());
        return this;
    }

    /// <summary>
    /// Lets every user share one entry. Use it only for a query that gives every user the same answer.
    /// </summary>
    /// <returns>The same rule, for chaining.</returns>
    public CatQueryCacheRule<TQuery> Shared()
    {
        IsShared = true;
        return this;
    }

    /// <summary>
    /// Caches a <c>NotFound</c> response too, for its own lifetime. A response with another failure is never cached.
    /// After an item is created, the old <c>NotFound</c> stays until the lifetime ends or its tag is removed.
    /// </summary>
    /// <param name="lifetime">How long a <c>NotFound</c> is kept, more than zero.</param>
    /// <returns>The same rule, for chaining.</returns>
    public CatQueryCacheRule<TQuery> CacheNotFound(TimeSpan lifetime)
    {
        RequirePositive(lifetime, nameof(lifetime));
        NotFoundExpiration = lifetime;
        return this;
    }

    /// <summary>
    /// Builds the part of the key that comes from the query, for a query where the serialized form is not right.
    /// The function must return the same text for queries that give the same answer, and a different text otherwise.
    /// </summary>
    /// <param name="keyFunction">Builds the key part from the query.</param>
    /// <returns>The same rule, for chaining.</returns>
    public CatQueryCacheRule<TQuery> Key(Func<TQuery, string> keyFunction)
    {
        if (keyFunction == null)
        {
            throw new ArgumentNullException(nameof(keyFunction));
        }

        KeyFunction = query => keyFunction((TQuery)query);
        return this;
    }
}
