using Cat.Demo.TodoService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.ToDoService.Core.Validators;

public class TodoGetRequestValidator : ICatValidator<TodoGetRequest>
{
    public void Build(ICatValidatorBuilder<TodoGetRequest> validator)
    {
        validator.AddPropertyRules(m => m.TodoId, b =>
        {
            b.NotNull();
        });
    }
}
