using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyClassNotEqualWithFuncValidator(TestSubModelFor_PropertyClassNotEqualWithFuncValidator Address, TestSubModelFor_PropertyClassNotEqualWithFuncValidator WrongAddress);

public class TestSubModelFor_PropertyClassNotEqualWithFuncValidator(string Street, int StreetNumber)
{
    public string Street { get; } = Street;
    public int StreetNumber { get; } = StreetNumber;

    public override string ToString()
    {
        return $"{Street} {StreetNumber}";
    }
}

public class TestSubModelFor_PropertyClassNotEqualWithFuncValidator_Comparer : IEqualityComparer<TestSubModelFor_PropertyClassNotEqualWithFuncValidator?>
{
    public bool Equals(TestSubModelFor_PropertyClassNotEqualWithFuncValidator? x, TestSubModelFor_PropertyClassNotEqualWithFuncValidator? y)
    {
        return x?.Street == y?.Street && x?.StreetNumber == y?.StreetNumber;
    }

    public int GetHashCode(TestSubModelFor_PropertyClassNotEqualWithFuncValidator obj)
    {
        return HashCode.Combine(obj.Street, obj.StreetNumber);
    }
}

public class PropertyClassNotEqualWithFuncValidator : ICatValidator<TestModelFor_PropertyClassNotEqualWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyClassNotEqualWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Address, b =>
        {
            b.NotEqual(
                t => t.WrongAddress,
                new TestSubModelFor_PropertyClassNotEqualWithFuncValidator_Comparer()
            );
        });
    }
}