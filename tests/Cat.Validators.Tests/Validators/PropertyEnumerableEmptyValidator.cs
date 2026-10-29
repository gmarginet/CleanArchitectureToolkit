using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyEnumerableEmptyValidator(IEnumerable<string> Names);

public class PropertyEnumerableEmptyValidator : ICatValidator<TestModelFor_PropertyEnumerableEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyEnumerableEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.Empty();
        });
    }
}