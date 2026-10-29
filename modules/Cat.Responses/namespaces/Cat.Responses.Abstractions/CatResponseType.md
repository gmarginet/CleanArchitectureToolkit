<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions')

## CatResponseType Class

Identifies the specific outcome of an operation, such as [Ok](CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') or [NotFound](CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\. Every outcome
is either a [Succeeded](CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded') or a [Failed](CatResponseType.Failed.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed') variant, so matching on the base type tells you
whether a response succeeded without inspecting the concrete outcome\.

```csharp
public abstract class CatResponseType
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatResponseType

Derived  
&#8627; [Failed](CatResponseType.Failed.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed')  
&#8627; [Succeeded](CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded')

| Properties | |
| :--- | :--- |
| [BadRequest](CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') | The operation failed because the request was invalid\. |
| [Created](CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') | The operation succeeded and created a new resource\. |
| [InternalServerError](CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') | The operation failed because of an unexpected error\. |
| [NoContent](CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') | The operation succeeded and has nothing to return\. |
| [NotFound](CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound') | The operation failed because the requested resource doesn't exist\. |
| [Ok](CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') | The operation succeeded\. |
| [Unauthorized](CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') | The operation failed because the caller isn't authorized to perform it\. |
