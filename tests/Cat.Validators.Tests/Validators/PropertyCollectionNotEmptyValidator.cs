using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyCollectionNotEmptyValidator(ICollection<string> Names);

public class PropertyCollectionNotEmptyValidator : ICatValidator<TestModelFor_PropertyCollectionNotEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyCollectionNotEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.NotEmpty();
        });
    }
}