<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions')

## ICatResponse Interface

Represents the outcome of an operation: whether it succeeded or failed, its specific [CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType'),
and any errors that caused it to fail\.

```csharp
public interface ICatResponse
```

Derived  
&#8627; [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')

| Properties | |
| :--- | :--- |
| [ErrorList](ICatResponse.ErrorList.md 'Cat\.Responses\.Abstractions\.ICatResponse\.ErrorList') | The errors that caused the operation to fail\. Empty when [IsSucceeded](ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\. |
| [IsFailed](ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') | `true` if the operation failed\. |
| [IsSucceeded](ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') | `true` if the operation succeeded\. |
| [Type](ICatResponse.Type.md 'Cat\.Responses\.Abstractions\.ICatResponse\.Type') | The specific outcome of the operation, such as [Ok](CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') or [NotFound](CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\. |

| Methods | |
| :--- | :--- |
| [Cast&lt;TResponse&gt;\(\)](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_() 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>'), carrying over its type and errors\. Only valid when [IsFailed](ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') is `true`, since no value is supplied for the succeeded case\. |
| [Cast&lt;TResponse&gt;\(TResponse\)](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse) 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(TResponse\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>') carrying the given value, keeping this response's type\. |
