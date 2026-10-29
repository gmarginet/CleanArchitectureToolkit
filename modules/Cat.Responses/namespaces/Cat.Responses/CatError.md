<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses')

## CatError Class

The default [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') implementation\. Create instances through its static `Create` overloads,
or build one from a reusable [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition') instead\.

```csharp
public record CatError : Cat.Responses.Abstractions.ICatError, System.IEquatable<Cat.Responses.CatError>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatError

Implements [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatError](CatError.md 'Cat\.Responses\.CatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatError\(string, string, object\[\]\)](CatError..ctor.6388ROMK40MNSHIGSSKKVZTIE.md 'Cat\.Responses\.CatError\.CatError\(string, string, object\[\]\)') | Creates an error with the given code, message, and arguments\. |

| Properties | |
| :--- | :--- |
| [Arguments](CatError.Arguments.md 'Cat\.Responses\.CatError\.Arguments') | The values to substitute into the message's placeholders, in order\. |
| [Code](CatError.Code.md 'Cat\.Responses\.CatError\.Code') | A stable code identifying the kind of error, independent of its message text\. |
| [Message](CatError.Message.md 'Cat\.Responses\.CatError\.Message') | A human\-readable message describing the error\. Can contain placeholders filled in by [Arguments](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.Arguments.md 'Cat\.Responses\.Abstractions\.ICatError\.Arguments')\. |

| Methods | |
| :--- | :--- |
| [Create\(string, string, object\[\]\)](CatError.Create.md#Cat.Responses.CatError.Create(string,string,object[]) 'Cat\.Responses\.CatError\.Create\(string, string, object\[\]\)') | Creates an error with the given code, message, and arguments\. |
| [Create\(string, string, List&lt;object&gt;\)](CatError.Create.md#Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_) 'Cat\.Responses\.CatError\.Create\(string, string, System\.Collections\.Generic\.List\<object\>\)') | Creates an error with the given code, message, and arguments\. |
