<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions') > [CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')

## CatResponseType\.Failed Class

Base type for every outcome that represents a failed operation\.

```csharp
public abstract class CatResponseType.Failed : Cat.Responses.Abstractions.CatResponseType
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType') &#129106; Failed

Derived  
&#8627; [BadRequest](CatResponseType.Failed.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.BadRequest')  
&#8627; [InternalServerError](CatResponseType.Failed.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.InternalServerError')  
&#8627; [NotFound](CatResponseType.Failed.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.NotFound')  
&#8627; [Unauthorized](CatResponseType.Failed.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.Unauthorized')