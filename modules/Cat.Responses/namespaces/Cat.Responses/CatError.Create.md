<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatError Class](CatError.md 'Cat\.Responses\.CatError')

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

The error message\. Can contain placeholders filled in by [arguments](CatError.Create.md#Cat.Responses.CatError.Create(string,string,object[]).arguments 'Cat\.Responses\.CatError\.Create\(string, string, object\[\]\)\.arguments')\.

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

The error message\. Can contain placeholders filled in by [argumentList](CatError.Create.md#Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_).argumentList 'Cat\.Responses\.CatError\.Create\(string, string, System\.Collections\.Generic\.List\<object\>\)\.argumentList')\.

<a name='Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_).argumentList'></a>

`argumentList` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The values to substitute into the message's placeholders, in order\.

#### Returns
[CatError](CatError.md 'Cat\.Responses\.CatError')  
The new error\.