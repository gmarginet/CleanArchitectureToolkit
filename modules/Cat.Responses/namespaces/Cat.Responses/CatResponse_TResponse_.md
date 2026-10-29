<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses')

## CatResponse\<TResponse\> Class

An [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1') implementation\. Created through the static factory methods on
[CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse') rather than its constructors directly\.

```csharp
public class CatResponse<TResponse> : Cat.Responses.CatResponse, Cat.Responses.Abstractions.ICatResponse<TResponse>, Cat.Responses.Abstractions.ICatResponse
```
#### Type parameters

<a name='Cat.Responses.CatResponse_TResponse_.TResponse'></a>

`TResponse`

The type of value the response carries\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse') &#129106; CatResponse\<TResponse\>

Implements [Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.TResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1'), [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

| Constructors | |
| :--- | :--- |
| [CatResponse\(Failed, IReadOnlyList&lt;ICatError&gt;\)](CatResponse_TResponse_.CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.Responses\.CatResponse\<TResponse\>\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Failed, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a failed response with the given errors\. |
| [CatResponse\(Succeeded\)](CatResponse_TResponse_.CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded) 'Cat\.Responses\.CatResponse\<TResponse\>\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\)') | Creates a succeeded response with no value\. |
| [CatResponse\(Succeeded, TResponse\)](CatResponse_TResponse_.CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded,TResponse) 'Cat\.Responses\.CatResponse\<TResponse\>\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded, TResponse\)') | Creates a succeeded response carrying the given value\. |

| Properties | |
| :--- | :--- |
| [Value](CatResponse_TResponse_.Value.md 'Cat\.Responses\.CatResponse\<TResponse\>\.Value') | The value the operation produced\. Only meaningful when [IsSucceeded](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\. |

| Methods | |
| :--- | :--- |
| [Cast&lt;TTargetResponse&gt;\(Func&lt;TResponse,TTargetResponse&gt;\)](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)') | Converts this response's value to another type, keeping its type and errors\. |
