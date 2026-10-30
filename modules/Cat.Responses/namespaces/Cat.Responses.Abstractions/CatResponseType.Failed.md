<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
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

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType') → Failed

Derived  
↳ [BadRequest](CatResponseType.Failed.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.BadRequest')  
↳ [InternalServerError](CatResponseType.Failed.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.InternalServerError')  
↳ [NotFound](CatResponseType.Failed.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.NotFound')  
↳ [Unauthorized](CatResponseType.Failed.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.Unauthorized')