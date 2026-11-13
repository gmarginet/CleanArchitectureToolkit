using System.Linq;
using Cat.Responses.Abstractions;
using NUnit.Framework.Constraints;

namespace Cat.UnitTesting.Responses.NUnit;

/// <summary>
/// A constraint that checks the outcome, the type and an error code of an <see cref="ICatResponse"/>.
/// Create it with <see cref="CatIs"/>. A failed check shows the response as it is, for example <c>Failed NotFound [DEM-ORD-1004]</c>.
/// </summary>
public sealed class CatResponseConstraint : Constraint
{
    private readonly bool _succeeded;
    private readonly CatResponseType? _type;
    private readonly string? _errorCode;

    /// <summary>
    /// Creates the constraint.
    /// </summary>
    /// <param name="succeeded"><c>true</c> when the response must have succeeded, <c>false</c> when it must have failed.</param>
    /// <param name="type">The type the response must have, or <c>null</c> for any type.</param>
    /// <param name="errorCode">The code that one of the errors must have, or <c>null</c> for no check.</param>
    public CatResponseConstraint(bool succeeded, CatResponseType? type, string? errorCode)
    {
        _succeeded = succeeded;
        _type = type;
        _errorCode = errorCode;
    }

    /// <inheritdoc />
    public override string Description
    {
        get
        {
            var text = _succeeded ? "a succeeded response" : "a failed response";

            if (_type != null)
            {
                text += " of type " + _type.GetType().Name;
            }

            if (_errorCode != null)
            {
                text += " with error " + _errorCode;
            }

            return text;
        }
    }

    /// <inheritdoc />
    public override ConstraintResult ApplyTo<TActual>(TActual actual)
    {
        if (!(actual is ICatResponse response))
        {
            return new ConstraintResult(this, actual, false);
        }

        var isMatch = response.IsSucceeded == _succeeded
            && (_type == null || response.Type.GetType() == _type.GetType())
            && (_errorCode == null || response.ErrorList.Any(error => error.Code == _errorCode));

        return new ConstraintResult(this, Describe(response), isMatch);
    }

    private static string Describe(ICatResponse response)
    {
        var text = (response.IsSucceeded ? "Succeeded " : "Failed ") + response.Type.GetType().Name;

        return response.ErrorList.Count == 0
            ? text
            : text + " [" + string.Join(", ", response.ErrorList.Select(error => error.Code)) + "]";
    }
}
