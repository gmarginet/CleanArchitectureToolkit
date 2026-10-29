using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator(int Discount, int MinDiscount, int MaxDiscount);

public class PropertyInclusiveBetweenWithFuncAndComparerValidator : ICatValidator<TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.InclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount, Comparer<int>.Default);
        });
    }
}