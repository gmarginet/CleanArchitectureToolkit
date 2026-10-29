using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyListEmptyValidator(IList<string> Names);

public class PropertyListEmptyValidator : ICatValidator<TestModelFor_PropertyListEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyListEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.Empty();
        });
    }
}