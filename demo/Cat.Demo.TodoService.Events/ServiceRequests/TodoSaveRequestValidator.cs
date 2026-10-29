using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.TodoService.Events.ServiceRequests;

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