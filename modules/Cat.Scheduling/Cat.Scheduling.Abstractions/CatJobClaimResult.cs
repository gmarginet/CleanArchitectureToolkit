namespace Cat.Scheduling.Abstractions;

/// <summary>
/// The outcome of asking for the claim of a job.
/// </summary>
public class CatJobClaimResult
{
    private CatJobClaimResult(CatJobClaimStatus status, CatJobClaim? claim)
    {
        Status = status;
        Claim = claim;
    }

    /// <summary>
    /// Whether the caller got the claim, and if not why.
    /// </summary>
    public CatJobClaimStatus Status { get; }

    /// <summary>
    /// The claim. Only set when <see cref="Status"/> is <see cref="CatJobClaimStatus.Claimed"/>.
    /// </summary>
    public CatJobClaim? Claim { get; }

    /// <summary>
    /// Creates the result for a claim that was given.
    /// </summary>
    /// <param name="claim">The claim.</param>
    /// <returns>The result.</returns>
    public static CatJobClaimResult Claimed(CatJobClaim claim) => new CatJobClaimResult(CatJobClaimStatus.Claimed, claim);

    /// <summary>
    /// Creates the result for a due time that another instance already claimed.
    /// </summary>
    /// <returns>The result.</returns>
    public static CatJobClaimResult TakenByOther() => new CatJobClaimResult(CatJobClaimStatus.TakenByOther, null);

    /// <summary>
    /// Creates the result for a job whose previous run is still busy.
    /// </summary>
    /// <returns>The result.</returns>
    public static CatJobClaimResult Busy() => new CatJobClaimResult(CatJobClaimStatus.Busy, null);
}
