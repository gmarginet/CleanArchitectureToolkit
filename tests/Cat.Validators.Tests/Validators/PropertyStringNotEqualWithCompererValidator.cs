using System;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringNotEqualWithComparerValidator(string Name);

public class PropertyStringNotEqualWithComparerValidator : ICatValidator<TestModelFor_PropertyStringNotEqualWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringNotEqualWithComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEqual("john doe", StringComparer.OrdinalIgnoreCase);
        });
    }
}