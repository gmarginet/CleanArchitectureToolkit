<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse Constructors

| Overloads | |
| :--- | :--- |
| [CatResponse\(Failed, IReadOnlyList&lt;ICatError&gt;\)](CatResponse.CatResponse.md#Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.Responses\.CatResponse\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Failed, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a failed response with the given errors\. |
| [CatResponse\(Succeeded\)](CatResponse.CatResponse.md#Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded) 'Cat\.Responses\.CatResponse\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\)') | Creates a succeeded response with no errors\. |

<a name='Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_)'></a>

## CatResponse\(Failed, IReadOnlyList\<ICatError\>\) Constructor

Creates a failed response with the given errors\.

```csharp
internal CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed type, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errorList);
```
#### Parameters

<a name='Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).type'></a>

`type` [Failed](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Failed.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed')

The specific failed outcome\.

<a name='Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).errorList'></a>

`errorList` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The errors that caused the operation to fail\.

<a name='Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded)'></a>

## CatResponse\(Succeeded\) Constructor

Creates a succeeded response with no errors\.

```csharp
internal CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded type);
```
#### Parameters

<a name='Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded).type'></a>

`type` [Succeeded](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded')

The specific succeeded outcome\.