namespace Cat.Responses;

/// <summary>
/// Distinguishes a succeeded response from a failed one.
/// </summary>
public enum CatResponseStatus
{
    /// <summary>The operation succeeded.</summary>
    Succeeded,
    /// <summary>The operation failed.</summary>
    Failed,
}