using System.Text.RegularExpressions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_NullableTextValidator(string? Name);

/// <summary>
/// Uses every string rule on a <c>string?</c> property. The tests prove that it compiles without a warning.
/// </summary>
public class NullableTextValidator : ICatValidator<TestModelFor_NullableTextValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_NullableTextValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.Length(2, 10);
            b.Length(_ => 2, _ => 10);
            b.ExactLength(5);
            b.ExactLength(_ => 5);
            b.MinimumLength(2);
            b.MinimumLength(_ => 2);
            b.MaximumLength(10);
            b.MaximumLength(_ => 10);
            b.MatchesRegex("^[a-z]+$");
            b.MatchesRegex(_ => "^[a-z]+$");
            b.MatchesRegex(new Regex("^[a-z]+$"));
            b.MatchesRegex(_ => new Regex("^[a-z]+$"));
        });
    }
}

public record TestModelFor_CharacterArrayTextValidator(char[]? Name);

public class CharacterArrayTextValidator : ICatValidator<TestModelFor_CharacterArrayTextValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_CharacterArrayTextValidator> validator)
    {
        validator.AddPropertyRules(t => t.Name, b =>
        {
            b.MaximumLength(3);
        });
    }
}
