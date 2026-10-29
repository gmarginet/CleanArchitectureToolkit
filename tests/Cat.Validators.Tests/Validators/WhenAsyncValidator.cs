using System.Threading.Tasks;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests.Validators;

// ReSharper disable InconsistentNaming
public record TestModelFor_WhenAsyncValidator(int Value, bool ShouldValidate);

public class WhenAsyncValidator : ICatValidator<TestModelFor_WhenAsyncValidator>
{
    public void Build(ICatValidatorBuilder<TestModelFor_WhenAsyncValidator> validator)
    {
        validator.AddPropertyRules(t => t.Value, b =>
        {
            b.GreaterThan(0).WhenAsync((t, _) => Task.FromResult(t.ShouldValidate));
        });
    }
}
