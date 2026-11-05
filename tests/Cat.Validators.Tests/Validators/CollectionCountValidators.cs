using System.Collections.Generic;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_PropertyMinimumCountValidator(IList<int>? Items);

public class PropertyMinimumCountValidator : ICatValidator<TestModelFor_PropertyMinimumCountValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMinimumCountValidator> validator)
    {
        validator.AddPropertyRules(t => t.Items, b => b.MinimumCount(2));
    }
}

public record TestModelFor_PropertyMaximumCountValidator(IEnumerable<int>? Items);

public class PropertyMaximumCountValidator : ICatValidator<TestModelFor_PropertyMaximumCountValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMaximumCountValidator> validator)
    {
        validator.AddPropertyRules(t => t.Items, b => b.MaximumCount(2));
    }
}

public record TestModelFor_PropertyMaximumCountWithFuncValidator(int[] Items, int Limit);

public class PropertyMaximumCountWithFuncValidator : ICatValidator<TestModelFor_PropertyMaximumCountWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyMaximumCountWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Items, b => b.MaximumCount(m => m.Limit));
    }
}

public record TestModelFor_PropertyCountBetweenValidator(int[] Items);

public class PropertyCountBetweenValidator : ICatValidator<TestModelFor_PropertyCountBetweenValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyCountBetweenValidator> validator)
    {
        validator.AddPropertyRules(t => t.Items, b => b.CountBetween(2, 3));
    }
}

public record TestModelFor_PropertyCountBetweenInvalidValidator(int[] Items);

public class PropertyCountBetweenInvalidValidator : ICatValidator<TestModelFor_PropertyCountBetweenInvalidValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyCountBetweenInvalidValidator> validator)
    {
        validator.AddPropertyRules(t => t.Items, b => b.CountBetween(3, 2));
    }
}

public record TestModelFor_PropertyCountBetweenWithFuncValidator(int[] Items, int Min, int Max);

public class PropertyCountBetweenWithFuncValidator : ICatValidator<TestModelFor_PropertyCountBetweenWithFuncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_PropertyCountBetweenWithFuncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Items, b => b.CountBetween(m => m.Min, m => m.Max));
    }
}
