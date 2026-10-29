using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Validators.Abstractions;

/// <summary>
/// Single entry point for validating a model.
/// It finds the validator for the model, runs its rules and returns the outcome as a response.
/// </summary>
public interface ICatValidatorProcessor
{
    /// <summary>
    /// Validates a model.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="model">The model to validate.</param>
    /// <param name="validatorRequired">When <c>true</c>, a missing validator throws. When <c>false</c>, the model counts as valid.</param>
    /// <param name="ct">Token to cancel the work.</param>
    /// <returns>An Ok response when the model is valid, or a BadRequest response with one error per failure.</returns>
    Task<ICatResponse> ValidateAsync<TModel>(TModel model, bool validatorRequired = true, CancellationToken ct = default)
        where TModel : class;

    /// <summary>
    /// Validates a model and blocks until it finishes.
    /// Prefer <see cref="ValidateAsync{TModel}(TModel, bool, CancellationToken)"/> when you can.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="model">The model to validate.</param>
    /// <param name="validatorRequired">When <c>true</c>, a missing validator throws. When <c>false</c>, the model counts as valid.</param>
    /// <returns>An Ok response when the model is valid, or a BadRequest response with one error per failure.</returns>
    ICatResponse Validate<TModel>(TModel model, bool validatorRequired = true)
        where TModel : class;
}