using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyClassEqualValidator(TestSubModelFor_PropertyClassEqualValidator Address);

public class TestSubModelFor_PropertyClassEqualValidator(string Street, int StreetNumber)
{
    public string Street { get; } = Street;
    public int StreetNumber { get; } = StreetNumber;

    public override string ToString()
    {
        return $"{Street} {StreetNumber}";
    }
}

public class TestSubModelFor_PropertyClassEqualValidator_Comparer : IEqualityComparer<TestSubModelFor_PropertyClassEqualValidator?>
{
    public bool Equals(TestSubModelFor_PropertyClassEqualValidator? x, TestSubModelFor_PropertyClassEqualValidator? y)
    {
        return x?.Street == y?.Street && x?.StreetNumber == y?.StreetNumber;
    }

    public int GetHashCode(TestSubModelFor_PropertyClassEqualValidator obj)
    {
        return HashCode.Combine(obj.Street, obj.StreetNumber);
    }
}

public class PropertyClassEqualValidator : ICatValidator<TestModelFor_PropertyClassEqualValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyClassEqualValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.Equal(
                new TestSubModelFor_PropertyClassEqualValidator("Dover Patrol", 10),
                new TestSubModelFor_PropertyClassEqualValidator_Comparer()
            );
        });
    }
}