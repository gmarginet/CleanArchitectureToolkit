using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using TARGET_NAMESPACE;

namespace ServiceName.CoreService.Validators;

/// <summary>Validates <see cref="ItemName"/>. Add a rule for each property that needs one.</summary>
public class ItemNameValidator : ICatValidator<ItemName>
{
    public void Build(ICatValidatorBuilder<ItemName> validator)
    {
        // validator.AddPropertyRules(m => m.Name, b => b.NotEmpty());
    }
}
