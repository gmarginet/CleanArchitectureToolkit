using Cat.Demo.TodoService.Contracts.ServiceRequests;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.ToDoService.Core.Validators;

public class TodoSaveRequestValidator : ICatValidator<TodoSaveRequest>
{
    public void Build(ICatValidatorBuilder<TodoSaveRequest> validator)
    {
        validator.AddPropertyRules(m => m.Todo, b =>
        {
            b.NotNull();
        });
    }
}
