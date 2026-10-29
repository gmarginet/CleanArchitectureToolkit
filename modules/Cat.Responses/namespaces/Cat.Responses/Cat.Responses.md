<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index')

## Cat\.Responses Namespace

Provides the default [ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') implementation and its response
factory methods, along with the error and error\-definition types used to describe why a response failed\.

| Classes | |
| :--- | :--- |
| [CatError](CatError.md 'Cat\.Responses\.CatError') | The default [ICatError](..\Cat.Responses.Abstractions\ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') implementation\. Create instances through its static `Create` overloads, or build one from a reusable [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition') instead\. |
| [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition') | A reusable definition for one kind of error: a stable code and a message template\. Define these once, as static fields, and call [CreateCatError\(object\[\]\)](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)') wherever that error needs to be raised with specific argument values\. |
| [CatGeneralErrorDefinitions](CatGeneralErrorDefinitions.md 'Cat\.Responses\.CatGeneralErrorDefinitions') | Common error definitions shared across CAT modules\. |
| [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse') | The default [ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') implementation\. Create instances through its static factory methods, such as [Ok\(\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok\(\)') and [NotFound\(ICatError\[\]\)](CatResponse.NotFound.md#Cat.Responses.CatResponse.NotFound(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.NotFound\(Cat\.Responses\.Abstractions\.ICatError\[\]\)'), rather than its constructors directly\. |
| [CatResponse&lt;TResponse&gt;](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>') | An [ICatResponse&lt;TResponse&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1') implementation\. Created through the static factory methods on [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse') rather than its constructors directly\. |

| Enums | |
| :--- | :--- |
| [CatResponseStatus](CatResponseStatus.md 'Cat\.Responses\.CatResponseStatus') | Distinguishes a succeeded response from a failed one\. |
