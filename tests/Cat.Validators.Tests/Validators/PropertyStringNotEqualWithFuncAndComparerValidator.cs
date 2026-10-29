using System;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyStringNotEqualWithFuncAndComparerValidator(string Name, string WrongName);

public class PropertyStringNotEqualWithFuncAndComparerValidator : ICatValidator<TestModelFor_PropertyStringNotEqualWithFuncAndComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyStringNotEqualWithFuncAndComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEqual(t => t.WrongName, StringComparer.OrdinalIgnoreCase);
        });
    }
}