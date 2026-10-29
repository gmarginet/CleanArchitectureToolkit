using System;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringEqualWithFuncAndComparerValidator(string Name, string ExpectedName);

public class PropertyStringEqualWithFuncAndComparerValidator : ICatValidator<TestModelFor_PropertyStringEqualWithFuncAndComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringEqualWithFuncAndComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Equal(t => t.ExpectedName, StringComparer.OrdinalIgnoreCase);
        });
    }
}