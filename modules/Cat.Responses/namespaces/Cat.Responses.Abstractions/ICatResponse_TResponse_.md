<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions')

## ICatResponse\<TResponse\> Interface

An [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') that carries a value when it succeeds\.

```csharp
public interface ICatResponse<TResponse> : Cat.Responses.Abstractions.ICatResponse
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatResponse_TResponse_.TResponse'></a>

`TResponse`

The type of value the response carries\.

Implements [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

| Properties | |
| :--- | :--- |
| [Value](ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Value') | The value the operation produced\. Only meaningful when [IsSucceeded](ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\. |

| Methods | |
| :--- | :--- |
| [Cast&lt;TTargetResponse&gt;\(Func&lt;TResponse,TTargetResponse&gt;\)](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)') | Converts this response's value to another type, keeping its type and errors\. |
