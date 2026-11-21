namespace Cat.Queries.Abstractions;

/// <summary>
/// The default order of the wrappers around <see cref="ICatQueryProcessor"/>, from the outside in.
/// A lower number is further out. It runs first on the way in and last on the way out.
/// Every module that wraps the processor uses one of these numbers, so the order is the same
/// whatever the sequence of the registration lines.
/// The numbers are spaced out in steps of 100, so a wrapper of your own can slot in between, for example 150.
/// </summary>
public static class CatQueryProcessorOrder
{
    /// <summary>
    /// The cache. A hit answers at once and never starts a retry.
    /// </summary>
    public const int Caching = 100;

    /// <summary>
    /// The retry. It sits inside the cache, so only a miss reaches it.
    /// </summary>
    public const int Retry = 200;
}
