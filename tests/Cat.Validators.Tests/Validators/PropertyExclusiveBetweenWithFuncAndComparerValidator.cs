using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator(int Discount, int MinDiscount, int MaxDiscount);

public class PropertyExclusiveBetweenWithFuncAndComparerValidator : ICatValidator<TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.ExclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount, Comparer<int>.Default);
        });
    }
}