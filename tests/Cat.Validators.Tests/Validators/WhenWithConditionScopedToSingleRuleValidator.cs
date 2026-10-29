using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_WhenWithConditionScopedToSingleRuleValidator(string Name, bool RunLengthRule);

public class WhenWithConditionScopedToSingleRuleValidator : ICatValidator<TestModelFor_WhenWithConditionScopedToSingleRuleValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_WhenWithConditionScopedToSingleRuleValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.NotEmpty();
            b.Length(5, 10).When(t => t.RunLengthRule);
        });
    }
}
