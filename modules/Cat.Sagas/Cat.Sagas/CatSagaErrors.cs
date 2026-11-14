using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Sagas;

internal static class CatSagaErrors
{
    private const string SagaErrorCodePrefix = "CAT-SAG";

    public static ICatError InstanceNotFound(System.Guid id)
        => CatError.Create($"{SagaErrorCodePrefix}-1001", "There is no saga instance with id {0}.", id);

    public static ICatError WorkflowNotRegistered(string name)
        => CatError.Create($"{SagaErrorCodePrefix}-1002", "The saga {0} is not registered. Call AddCatSaga for its workflow.", name);

    public static ICatError ResumeFailed(string reason)
        => CatError.Create($"{SagaErrorCodePrefix}-1003", "The saga cannot be resumed: {0}", reason);
}
