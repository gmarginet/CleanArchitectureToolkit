using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
// Every validator below runs one rule on a string? or int? property. They prove that the rules compile without a warning.

public record TestModelFor_NullableStringNotNullValidator(string? Name);

public class NullableStringNotNullValidator : ICatValidator<TestModelFor_NullableStringNotNullValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringNotNullValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.NotNull());
}

public record TestModelFor_NullableStringNullValidator(string? Name);

public class NullableStringNullValidator : ICatValidator<TestModelFor_NullableStringNullValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringNullValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.Null());
}

public record TestModelFor_NullableStringNotEmptyValidator(string? Name);

public class NullableStringNotEmptyValidator : ICatValidator<TestModelFor_NullableStringNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringNotEmptyValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.NotEmpty());
}

public record TestModelFor_NullableStringEmptyValidator(string? Name);

public class NullableStringEmptyValidator : ICatValidator<TestModelFor_NullableStringEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringEmptyValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.Empty());
}

public record TestModelFor_NullableStringEqualValidator(string? Name);

public class NullableStringEqualValidator : ICatValidator<TestModelFor_NullableStringEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringEqualValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.Equal("abc"));
}

public record TestModelFor_NullableStringEqualWithComparerValidator(string? Name);

public class NullableStringEqualWithComparerValidator : ICatValidator<TestModelFor_NullableStringEqualWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringEqualWithComparerValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.Equal("abc", StringComparer.OrdinalIgnoreCase));
}

public record TestModelFor_NullableStringEqualWithExpressionValidator(string? Name, string? Other);

public class NullableStringEqualWithExpressionValidator : ICatValidator<TestModelFor_NullableStringEqualWithExpressionValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringEqualWithExpressionValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.Equal(t => t.Other));
}

public record TestModelFor_NullableStringNotEqualValidator(string? Name);

public class NullableStringNotEqualValidator : ICatValidator<TestModelFor_NullableStringNotEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringNotEqualValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.NotEqual("abc"));
}

public record TestModelFor_NullableStringNotEqualWithComparerValidator(string? Name);

public class NullableStringNotEqualWithComparerValidator : ICatValidator<TestModelFor_NullableStringNotEqualWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringNotEqualWithComparerValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.NotEqual("abc", StringComparer.OrdinalIgnoreCase));
}

public record TestModelFor_NullableStringLessThanValidator(string? Name);

public class NullableStringLessThanValidator : ICatValidator<TestModelFor_NullableStringLessThanValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringLessThanValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.LessThan("m"));
}

public record TestModelFor_NullableStringGreaterThanOrEqualToValidator(string? Name);

public class NullableStringGreaterThanOrEqualToValidator : ICatValidator<TestModelFor_NullableStringGreaterThanOrEqualToValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringGreaterThanOrEqualToValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.GreaterThanOrEqualTo("m"));
}

public record TestModelFor_NullableStringLessThanWithExpressionValidator(string? Name, string? Limit);

public class NullableStringLessThanWithExpressionValidator : ICatValidator<TestModelFor_NullableStringLessThanWithExpressionValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringLessThanWithExpressionValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.LessThan(t => t.Limit));
}

public record TestModelFor_NullableStringInclusiveBetweenValidator(string? Name);

public class NullableStringInclusiveBetweenValidator : ICatValidator<TestModelFor_NullableStringInclusiveBetweenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringInclusiveBetweenValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.InclusiveBetween("b", "y"));
}

public record TestModelFor_NullableStringExclusiveBetweenWithComparerValidator(string? Name);

public class NullableStringExclusiveBetweenWithComparerValidator : ICatValidator<TestModelFor_NullableStringExclusiveBetweenWithComparerValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringExclusiveBetweenWithComparerValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.ExclusiveBetween("b", "y", StringComparer.Ordinal));
}

public record TestModelFor_NullableStringMustValidator(string? Name);

public class NullableStringMustValidator : ICatValidator<TestModelFor_NullableStringMustValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableStringMustValidator> validator)
        => validator.AddPropertyRules(t => t.Name, b => b.Must((value, fieldName) =>
            value is null
                ? [CatValidatorError.Create("TEST-1", fieldName, "Name is missing.")]
                : CatValidatorResult.Valid()));
}

public record TestModelFor_NullableIntegerNotEmptyValidator(int? Count);

public class NullableIntegerNotEmptyValidator : ICatValidator<TestModelFor_NullableIntegerNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableIntegerNotEmptyValidator> validator)
        => validator.AddPropertyRules(t => t.Count, b => b.NotEmpty());
}

public record TestModelFor_NullableIntegerEqualValidator(int? Count);

public class NullableIntegerEqualValidator : ICatValidator<TestModelFor_NullableIntegerEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableIntegerEqualValidator> validator)
        => validator.AddPropertyRules(t => t.Count, b => b.Equal(1));
}

public record TestModelFor_NullableIntegerNotEqualValidator(int? Count);

public class NullableIntegerNotEqualValidator : ICatValidator<TestModelFor_NullableIntegerNotEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableIntegerNotEqualValidator> validator)
        => validator.AddPropertyRules(t => t.Count, b => b.NotEqual(1));
}
