<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatError](CatError.md 'Cat\.Responses\.CatError')

## CatError\.Create Method

| Overloads | |
| :--- | :--- |
| [Create\(string, string, object\[\]\)](CatError.Create.md#Cat.Responses.CatError.Create(string,string,object[]) 'Cat\.Responses\.CatError\.Create\(string, string, object\[\]\)') | Creates an error with the given code, message, and arguments\. |
| [Create\(string, string, List&lt;object&gt;\)](CatError.Create.md#Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_) 'Cat\.Responses\.CatError\.Create\(string, string, System\.Collections\.Generic\.List\<object\>\)') | Creates an error with the given code, message, and arguments\. |

<a name='Cat.Responses.CatError.Create(string,string,object[])'></a>

## CatError\.Create\(string, string, object\[\]\) Method

Creates an error with the given code, message, and arguments\.

```csharp
public static Cat.Responses.CatError Create(string code, string message, params object?[] arguments);
```
#### Parameters

<a name='Cat.Responses.CatError.Create(string,string,object[]).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The stable code identifying this kind of error\.

<a name='Cat.Responses.CatError.Create(string,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message\. Can contain placeholders filled in by [arguments](CatError.md#Cat.Responses.CatError.Create(string,string,object[]).arguments 'Cat\.Responses\.CatError\.Create\(string, string, object\[\]\)\.arguments')\.

<a name='Cat.Responses.CatError.Create(string,string,object[]).arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the message's placeholders, in order\.

#### Returns
[CatError](CatError.md 'Cat\.Responses\.CatError')  
The new error\.

<a name='Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_)'></a>

## CatError\.Create\(string, string, List\<object\>\) Method

Creates an error with the given code, message, and arguments\.

```csharp
public static Cat.Responses.CatError Create(string code, string message, System.Collections.Generic.List<object?> argumentList);
```
#### Parameters

<a name='Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The stable code identifying this kind of error\.

<a name='Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message\. Can contain placeholders filled in by [argumentList](CatError.md#Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_).argumentList 'Cat\.Responses\.CatError\.Create\(string, string, System\.Collections\.Generic\.List\<object\>\)\.argumentList')\.

<a name='Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_).argumentList'></a>

`argumentList` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The values to substitute into the message's placeholders, in order\.

#### Returns
[CatError](CatError.md 'Cat\.Responses\.CatError')  
The new error\.