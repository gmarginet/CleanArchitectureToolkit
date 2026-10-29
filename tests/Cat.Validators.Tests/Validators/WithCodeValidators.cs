using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming

public record TestModelFor_WithCodeValidator(string Name);

public class WithCodeValidator : ICatValidator<TestModelFor_WithCodeValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_WithCodeValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEmpty().WithCode("APP-1001");
        });
    }
}

public record TestModelFor_AllRuleOptionsValidator(string Name);

public class AllRuleOptionsValidator : ICatValidator<TestModelFor_AllRuleOptionsValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_AllRuleOptionsValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MaximumLength(3)
                .WithCode("APP-1002")
                .WithFieldName("name")
                .WithMessage("Too long, the limit is {maxLength}.");
        });
    }
}

public record TestModelFor_MultipleRulesOnOnePropertyValidator(string Name);

public class MultipleRulesOnOnePropertyValidator : ICatValidator<TestModelFor_MultipleRulesOnOnePropertyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_MultipleRulesOnOnePropertyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEmpty();
            b.MinimumLength(3);
            b.MatchesRegex("^[A-Z]");
        });
    }
}

/// <summary>
/// A generic validator. The module skips generic validators when it scans.
/// </summary>
public class GenericModelValidator<T> : ICatValidator<TestModelFor_WithCodeValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_WithCodeValidator> validator)
    {
    }
}
