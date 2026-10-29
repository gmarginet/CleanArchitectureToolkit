using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyClassEqualWithFuncValidator(TestSubModelFor_PropertyClassEqualWithFuncValidator Address, TestSubModelFor_PropertyClassEqualWithFuncValidator ExpectedAddress);

public class TestSubModelFor_PropertyClassEqualWithFuncValidator(string Street, int StreetNumber)
{
    public string Street { get; } = Street;
    public int StreetNumber { get; } = StreetNumber;

    public override string ToString()
    {
        return $"{Street} {StreetNumber}";
    }
}

public class TestSubModelFor_PropertyClassEqualWithFuncValidator_Comparer : IEqualityComparer<TestSubModelFor_PropertyClassEqualWithFuncValidator?>
{
    public bool Equals(TestSubModelFor_PropertyClassEqualWithFuncValidator? x, TestSubModelFor_PropertyClassEqualWithFuncValidator? y)
    {
        return x?.Street == y?.Street && x?.StreetNumber == y?.StreetNumber;
    }

    public int GetHashCode(TestSubModelFor_PropertyClassEqualWithFuncValidator obj)
    {
        return HashCode.Combine(obj.Street, obj.StreetNumber);
    }
}

public class PropertyClassEqualWithFuncValidator : ICatValidator<TestModelFor_PropertyClassEqualWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyClassEqualWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.Equal(
                t => t.ExpectedAddress,
                new TestSubModelFor_PropertyClassEqualWithFuncValidator_Comparer()
            );
        });
    }
}