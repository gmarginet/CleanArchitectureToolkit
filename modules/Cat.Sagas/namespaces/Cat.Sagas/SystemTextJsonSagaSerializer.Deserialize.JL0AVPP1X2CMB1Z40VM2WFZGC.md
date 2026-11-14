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
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [SystemTextJsonSagaSerializer Class](SystemTextJsonSagaSerializer.md 'Cat\.Sagas\.SystemTextJsonSagaSerializer')

## SystemTextJsonSagaSerializer\.Deserialize\(string, Type\) Method

Turns text back into a value\.

```csharp
public object Deserialize(string text, System.Type type);
```
#### Parameters

<a name='Cat.Sagas.SystemTextJsonSagaSerializer.Deserialize(string,System.Type).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text from [Serialize\(object, Type\)](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaSerializer.Serialize.PZZU9XGTUUKW2A5LO4CFETFA.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer\.Serialize\(System\.Object,System\.Type\)')\.

<a name='Cat.Sagas.SystemTextJsonSagaSerializer.Deserialize(string,System.Type).type'></a>

`type` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The type of the value\.

Implements [Deserialize\(string, Type\)](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaSerializer.Deserialize.D6W389TA4R4MUX10XC4PP2A74.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer\.Deserialize\(System\.String,System\.Type\)')

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
The value\.