using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyCollectionEmptyValidator(ICollection<string> Names);

public class PropertyCollectionEmptyValidator : ICatValidator<TestModelFor_PropertyCollectionEmptyValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyCollectionEmptyValidator> validator)
    {
        validator.AddPropertyRules(t => t.Names, b =>
        {
            b.Empty();
        });
    }
}