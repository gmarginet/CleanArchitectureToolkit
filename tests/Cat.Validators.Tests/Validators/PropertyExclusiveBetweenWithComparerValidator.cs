using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyExclusiveBetweenWithComparerValidator(int Discount);

public class PropertyExclusiveBetweenWithComparerValidator : ICatValidator<TestModelFor_PropertyExclusiveBetweenWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyExclusiveBetweenWithComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.ExclusiveBetween(10, 20, Comparer<int>.Default);
        });
    }
}