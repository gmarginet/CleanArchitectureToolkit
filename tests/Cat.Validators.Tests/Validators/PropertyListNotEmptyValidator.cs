using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyListNotEmptyValidator(IList<string> Names);

public class PropertyListNotEmptyValidator : ICatValidator<TestModelFor_PropertyListNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyListNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.NotEmpty();
        });
    }
}