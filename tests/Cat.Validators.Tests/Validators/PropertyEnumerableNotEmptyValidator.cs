using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyEnumerableNotEmptyValidator(IEnumerable<string> Names);

public class PropertyEnumerableNotEmptyValidator : ICatValidator<TestModelFor_PropertyEnumerableNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyEnumerableNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.NotEmpty();
        });
    }
}