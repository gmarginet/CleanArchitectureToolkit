using System;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringEqualWithComparerValidator(string Name);

public class PropertyStringEqualWithComparerValidator : ICatValidator<TestModelFor_PropertyStringEqualWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringEqualWithComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Equal("john doe", StringComparer.OrdinalIgnoreCase);
        });
    }
}