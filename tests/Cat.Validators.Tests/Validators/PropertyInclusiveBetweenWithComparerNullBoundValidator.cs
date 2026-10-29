using System;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyInclusiveBetweenWithComparerNullBoundValidator(string Value);

public class PropertyInclusiveBetweenWithComparerNullBoundValidator : ICatValidator<TestModelFor_PropertyInclusiveBetweenWithComparerNullBoundValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyInclusiveBetweenWithComparerNullBoundValidator> validator)
    {
        validator.AddPropertyRules(t => t.Value, b =>
        {
            b.InclusiveBetween(null!, "z", StringComparer.Ordinal); // null lowerBound, invalid on purpose
        });
    }
}
