using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyClassNotEqualValidator(TestSubModelFor_PropertyClassNotEqualValidator Address);

public class TestSubModelFor_PropertyClassNotEqualValidator(string Street, int StreetNumber)
{
    public string Street { get; } = Street;
    public int StreetNumber { get; } = StreetNumber;

    public override string ToString()
    {
        return $"{Street} {StreetNumber}";
    }
}

public class
    TestSubModelFor_PropertyClassNotEqualValidator_Comparer : IEqualityComparer<
    TestSubModelFor_PropertyClassNotEqualValidator?>
{
    public bool Equals(TestSubModelFor_PropertyClassNotEqualValidator? x,
        TestSubModelFor_PropertyClassNotEqualValidator? y)
    {
        return x?.Street == y?.Street && x?.StreetNumber == y?.StreetNumber;
    }

    public int GetHashCode(TestSubModelFor_PropertyClassNotEqualValidator obj)
    {
        return HashCode.Combine(obj.Street, obj.StreetNumber);
    }
}

public class PropertyClassNotEqualValidator : ICatValidator<TestModelFor_PropertyClassNotEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyClassNotEqualValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.NotEqual(
                new TestSubModelFor_PropertyClassNotEqualValidator("Dover Patrol", 10),
                new TestSubModelFor_PropertyClassNotEqualValidator_Comparer()
            );
        });
    }
}