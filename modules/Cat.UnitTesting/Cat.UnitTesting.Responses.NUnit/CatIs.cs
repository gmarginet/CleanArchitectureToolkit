using Cat.Responses.Abstractions;
using NUnit.Framework.Constraints;

namespace Cat.UnitTesting.Responses.NUnit;

/// <summary>
/// NUnit constraints for an <see cref="ICatResponse"/>. Use them with <c>Assert.That</c>, for example
/// <c>Assert.That(response, CatIs.Succeeded)</c> or <c>Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound, "DEM-ORD-1004"))</c>.
/// </summary>
public static class CatIs
{
    /// <summary>
    /// The response succeeded, with any success type.
    /// </summary>
    public static CatResponseConstraint Succeeded => new CatResponseConstraint(true, null, null);

    /// <summary>
    /// The response succeeded with this type, such as <see cref="CatResponseType.Created"/>.
    /// </summary>
    /// <param name="type">The success type, taken from <see cref="CatResponseType"/>.</param>
    public static CatResponseConstraint SucceededWith(CatResponseType type) => new CatResponseConstraint(true, type, null);

    /// <summary>
    /// The response failed, with any failure type and any errors.
    /// </summary>
    public static CatResponseConstraint Failed => new CatResponseConstraint(false, null, null);

    /// <summary>
    /// The response failed with this type, such as <see cref="CatResponseType.NotFound"/>.
    /// </summary>
    /// <param name="type">The failure type, taken from <see cref="CatResponseType"/>.</param>
    public static CatResponseConstraint FailedWith(CatResponseType type) => new CatResponseConstraint(false, type, null);

    /// <summary>
    /// The response failed and one of its errors has this code.
    /// </summary>
    /// <param name="errorCode">The code of the error, such as <c>DEM-ORD-1004</c>.</param>
    public static CatResponseConstraint FailedWithCode(string errorCode) => new CatResponseConstraint(false, null, errorCode);

    /// <summary>
    /// The response failed with this type and one of its errors has this code.
    /// </summary>
    /// <param name="type">The failure type, taken from <see cref="CatResponseType"/>.</param>
    /// <param name="errorCode">The code of the error, such as <c>DEM-ORD-1004</c>.</param>
    public static CatResponseConstraint FailedWith(CatResponseType type, string errorCode) => new CatResponseConstraint(false, type, errorCode);
}
