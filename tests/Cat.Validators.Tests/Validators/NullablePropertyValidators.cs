using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming

#region Comparison with a value

public record TestModelFor_NullableLessThanValidator(int? Discount);

public class NullableLessThanValidator : ICatValidator<TestModelFor_NullableLessThanValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableLessThanValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.LessThan(10); });
    }
}

public record TestModelFor_NullableLessThanOrEqualToValidator(int? Discount);

public class NullableLessThanOrEqualToValidator : ICatValidator<TestModelFor_NullableLessThanOrEqualToValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableLessThanOrEqualToValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.LessThanOrEqualTo(10); });
    }
}

public record TestModelFor_NullableGreaterThanValidator(int? Discount);

public class NullableGreaterThanValidator : ICatValidator<TestModelFor_NullableGreaterThanValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableGreaterThanValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.GreaterThan(10); });
    }
}

public record TestModelFor_NullableGreaterThanOrEqualToValidator(decimal? Price);

public class NullableGreaterThanOrEqualToValidator : ICatValidator<TestModelFor_NullableGreaterThanOrEqualToValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableGreaterThanOrEqualToValidator> validator)
    {
        validator.AddPropertyRules(t => t.Price, b => { b.GreaterThanOrEqualTo(10m); });
    }
}

#endregion Comparison with a value

#region Comparison with another property

public record TestModelFor_NullableLessThanWithExpressionValidator(int? Discount, int? MaxDiscount);

public class NullableLessThanWithExpressionValidator : ICatValidator<TestModelFor_NullableLessThanWithExpressionValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableLessThanWithExpressionValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.LessThan(t => t.MaxDiscount); });
    }
}

public record TestModelFor_NullableLessThanOrEqualToWithExpressionValidator(int? Discount, int? MaxDiscount);

public class NullableLessThanOrEqualToWithExpressionValidator : ICatValidator<TestModelFor_NullableLessThanOrEqualToWithExpressionValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableLessThanOrEqualToWithExpressionValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.LessThanOrEqualTo(t => t.MaxDiscount); });
    }
}

public record TestModelFor_NullableGreaterThanWithExpressionValidator(int? Discount, int? MinDiscount);

public class NullableGreaterThanWithExpressionValidator : ICatValidator<TestModelFor_NullableGreaterThanWithExpressionValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableGreaterThanWithExpressionValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.GreaterThan(t => t.MinDiscount); });
    }
}

public record TestModelFor_NullableGreaterThanOrEqualToWithExpressionValidator(int? Discount, int? MinDiscount);

public class NullableGreaterThanOrEqualToWithExpressionValidator : ICatValidator<TestModelFor_NullableGreaterThanOrEqualToWithExpressionValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableGreaterThanOrEqualToWithExpressionValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.GreaterThanOrEqualTo(t => t.MinDiscount); });
    }
}

#endregion Comparison with another property

#region Inclusive between

public record TestModelFor_NullableInclusiveBetweenValidator(int? Discount);

public class NullableInclusiveBetweenValidator : ICatValidator<TestModelFor_NullableInclusiveBetweenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableInclusiveBetweenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.InclusiveBetween(5, 10); });
    }
}

public record TestModelFor_NullableInclusiveBetweenWithFuncValidator(int? Discount, int? MinDiscount, int? MaxDiscount);

public class NullableInclusiveBetweenWithFuncValidator : ICatValidator<TestModelFor_NullableInclusiveBetweenWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableInclusiveBetweenWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.InclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount); });
    }
}

public record TestModelFor_NullableInclusiveBetweenWithComparerValidator(int? Discount);

public class NullableInclusiveBetweenWithComparerValidator : ICatValidator<TestModelFor_NullableInclusiveBetweenWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableInclusiveBetweenWithComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.InclusiveBetween(5, 10, Comparer<int>.Default); });
    }
}

public record TestModelFor_NullableInclusiveBetweenWithFuncAndComparerValidator(int? Discount, int? MinDiscount, int? MaxDiscount);

public class NullableInclusiveBetweenWithFuncAndComparerValidator : ICatValidator<TestModelFor_NullableInclusiveBetweenWithFuncAndComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableInclusiveBetweenWithFuncAndComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.InclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount, Comparer<int>.Default); });
    }
}

public record TestModelFor_NullableInclusiveBetweenInvalidValidator(int? Discount);

public class NullableInclusiveBetweenInvalidValidator : ICatValidator<TestModelFor_NullableInclusiveBetweenInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableInclusiveBetweenInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.InclusiveBetween(10, 5); });
    }
}

#endregion Inclusive between

#region Exclusive between

public record TestModelFor_NullableExclusiveBetweenValidator(int? Discount);

public class NullableExclusiveBetweenValidator : ICatValidator<TestModelFor_NullableExclusiveBetweenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableExclusiveBetweenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.ExclusiveBetween(5, 10); });
    }
}

public record TestModelFor_NullableExclusiveBetweenWithFuncValidator(int? Discount, int? MinDiscount, int? MaxDiscount);

public class NullableExclusiveBetweenWithFuncValidator : ICatValidator<TestModelFor_NullableExclusiveBetweenWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableExclusiveBetweenWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.ExclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount); });
    }
}

public record TestModelFor_NullableExclusiveBetweenWithComparerValidator(int? Discount);

public class NullableExclusiveBetweenWithComparerValidator : ICatValidator<TestModelFor_NullableExclusiveBetweenWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableExclusiveBetweenWithComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.ExclusiveBetween(5, 10, Comparer<int>.Default); });
    }
}

public record TestModelFor_NullableExclusiveBetweenWithFuncAndComparerValidator(int? Discount, int? MinDiscount, int? MaxDiscount);

public class NullableExclusiveBetweenWithFuncAndComparerValidator : ICatValidator<TestModelFor_NullableExclusiveBetweenWithFuncAndComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableExclusiveBetweenWithFuncAndComparerValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.ExclusiveBetween(t => t.MinDiscount, t => t.MaxDiscount, Comparer<int>.Default); });
    }
}

public record TestModelFor_NullableExclusiveBetweenInvalidValidator(int? Discount);

public class NullableExclusiveBetweenInvalidValidator : ICatValidator<TestModelFor_NullableExclusiveBetweenInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableExclusiveBetweenInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b => { b.ExclusiveBetween(10, 5); });
    }
}

#endregion Exclusive between

#region Chaining

public record TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator(decimal? Price);

public class NullableNotNullAndGreaterThanOrEqualToValidator : ICatValidator<TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator> validator)
    {
        validator.AddPropertyRules(t => t.Price, b =>
        {
            b.NotNull();
            b.GreaterThanOrEqualTo(0m);
        });
    }
}

public record TestModelFor_NullableWithOptionsValidator(int? Discount);

public class NullableWithOptionsValidator : ICatValidator<TestModelFor_NullableWithOptionsValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableWithOptionsValidator> validator)
    {
        validator.AddPropertyRules(t => t.Discount, b =>
        {
            b.GreaterThan(10).WithFieldName("Rebate").WithCode("MY-1").WithMessage("Too low.");
        });
    }
}

#endregion Chaining
