using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyInclusiveBetweenWithComparerValidator(int Discount);

public class PropertyInclusiveBetweenWithComparerValidator : ICatValidator<TestModelFor_PropertyInclusiveBetweenWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyInclusiveBetweenWithComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.InclusiveBetween(10, 20, Comparer<int>.Default);
        });
    }
}