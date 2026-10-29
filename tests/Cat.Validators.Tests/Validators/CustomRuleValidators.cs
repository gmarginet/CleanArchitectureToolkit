using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming

/// <summary>
/// A property rule that works synchronously, like the one in the README.
/// </summary>
public class PropertyStartsWithTodoRule<TModel> : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
        return value.StartsWith("TODO")
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: ErrorCode ?? "APP-1001",
                    fieldName: FieldName ?? fieldName,
                    message: ErrorMessage ?? "'{propertyName}' should start with TODO."));
    }
}

/// <summary>
/// A property rule that works asynchronously.
/// </summary>
public class PropertyIsNotBlankAsyncRule<TModel> : CatValidatorPropertyRuleAsyncBase<TModel, string>
    where TModel : class
{
    protected override async Task<List<ICatValidatorError>> ValidateAsync(string value, string fieldName, TModel model, CancellationToken ct)
    {
        await Task.Yield();

        return string.IsNullOrWhiteSpace(value)
            ? CatValidatorResult.Invalid(CatValidatorError.Create("APP-2001", fieldName, "'{propertyName}' is blank."))
            : CatValidatorResult.Valid();
    }
}

/// <summary>
/// A rule that looks at the whole model.
/// </summary>
public class FirstAndSecondDifferRule : CatValidatorModelRuleBase<TestModelFor_CustomModelRuleValidator>
{
    protected override List<ICatValidatorError> Validate(TestModelFor_CustomModelRuleValidator model)
    {
        return model.First == model.Second
            ? CatValidatorResult.Invalid(CatValidatorError.Create("APP-3001", "First", "'{propertyName}' should differ from the second one."))
            : CatValidatorResult.Valid();
    }
}

public static class CustomRuleExtensions
{
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> StartsWithTodo<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder)
        where TModel : class
    {
        return builder.AddPropertyRule(new PropertyStartsWithTodoRule<TModel>());
    }

    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> IsNotBlankAsync<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder)
        where TModel : class
    {
        return builder.AddPropertyRule(new PropertyIsNotBlankAsyncRule<TModel>());
    }
}

public record TestModelFor_CustomRuleValidator(string Title);

public class CustomRuleValidator : ICatValidator<TestModelFor_CustomRuleValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_CustomRuleValidator> validator)
    {
        validator.AddPropertyRules(t => t.Title, b => b.StartsWithTodo());
    }
}

public record TestModelFor_CustomRuleWithOptionsValidator(string Title, bool Check);

public class CustomRuleWithOptionsValidator : ICatValidator<TestModelFor_CustomRuleWithOptionsValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_CustomRuleWithOptionsValidator> validator)
    {
        validator.AddPropertyRules(t => t.Title, b =>
        {
            b.StartsWithTodo()
                .WithCode("APP-9001")
                .WithFieldName("title")
                .WithMessage("Start with TODO please.")
                .When(t => t.Check);
        });
    }
}

public record TestModelFor_CustomAsyncRuleValidator(string Title);

public class CustomAsyncRuleValidator : ICatValidator<TestModelFor_CustomAsyncRuleValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_CustomAsyncRuleValidator> validator)
    {
        validator.AddPropertyRules(t => t.Title, b => b.IsNotBlankAsync());
    }
}

public record TestModelFor_CustomModelRuleValidator(string First, string Second);

public class CustomModelRuleValidator : ICatValidator<TestModelFor_CustomModelRuleValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_CustomModelRuleValidator> validator)
    {
        validator.AddRules(b => b.AddRule(new FirstAndSecondDifferRule()));
    }
}
