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
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index') >> [Cat\.Sagas\.Abstractions Namespace](Cat.Sagas.Abstractions.md 'Cat\.Sagas\.Abstractions')

## CatSagaConcurrencyException Class

Thrown by a store when another message changed the instance since it was loaded\.
Let it pass\. The message is delivered again and the next try sees the new state\.

```csharp
public class CatSagaConcurrencyException : System.Exception
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') → CatSagaConcurrencyException

| Constructors | |
| :--- | :--- |
| [CatSagaConcurrencyException\(Guid\)](CatSagaConcurrencyException..ctor.ONM2WVWI4SFRVQMKJZ9465DK6.md 'Cat\.Sagas\.Abstractions\.CatSagaConcurrencyException\.CatSagaConcurrencyException\(System\.Guid\)') | Creates the exception\. |

| Properties | |
| :--- | :--- |
| [InstanceId](CatSagaConcurrencyException.InstanceId.md 'Cat\.Sagas\.Abstractions\.CatSagaConcurrencyException\.InstanceId') | The id of the instance that changed\. |
