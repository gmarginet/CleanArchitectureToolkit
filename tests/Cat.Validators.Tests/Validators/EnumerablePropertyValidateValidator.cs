using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_EnumerablePropertyValidateValidator(string Name, IList<TestSubModelFor_PropertyValidateValidator?>? Addresses);

public record TestSubModelFor_EnumerablePropertyValidateValidator(string Street, int Number);

public class TestSubModelFor_CollectionPropertyValidateValidator_Validator : ICatValidator<TestSubModelFor_EnumerablePropertyValidateValidator>
{
    public void Build(ICatValidatorBuilder<TestSubModelFor_EnumerablePropertyValidateValidator> validator)
    {
        validator.AddPropertyRules(t => t.Street, b =>
        {
            b.NotEmpty();
        });
        validator.AddPropertyRules(t => t.Number, b =>
        {
            b.GreaterThan(0);
        });
    }
}

public class EnumerablePropertyValidateValidator : ICatValidator<TestModelFor_EnumerablePropertyValidateValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_EnumerablePropertyValidateValidator> validator)
    {
        validator.AddPropertyRules(t => t.Addresses, b =>
        {
            b.ValidateEnumerable();
        });
    }
}
