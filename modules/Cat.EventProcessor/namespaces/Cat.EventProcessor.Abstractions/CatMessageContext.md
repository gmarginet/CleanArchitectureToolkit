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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index') >> [Cat\.EventProcessor\.Abstractions Namespace](Cat.EventProcessor.Abstractions.md 'Cat\.EventProcessor\.Abstractions')

## CatMessageContext Class

The message that is being handled right now\. Code in the handler pipeline, such as the inbox decorator, reads it\.
It is empty when a service request does not come from a message, for example from an HTTP call\.

```csharp
public static class CatMessageContext
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageContext

| Constructors | |
| :--- | :--- |
| [CatMessageContext\(\)](CatMessageContext.CatMessageContext().md 'Cat\.EventProcessor\.Abstractions\.CatMessageContext\.CatMessageContext\(\)') | |

| Fields | |
| :--- | :--- |
| [CurrentData](CatMessageContext.CurrentData.md 'Cat\.EventProcessor\.Abstractions\.CatMessageContext\.CurrentData') | |

| Properties | |
| :--- | :--- |
| [Current](CatMessageContext.Current.md 'Cat\.EventProcessor\.Abstractions\.CatMessageContext\.Current') | The message that is being handled, or null\. |

| Methods | |
| :--- | :--- |
| [Begin\(string, int\)](CatMessageContext.Begin.TT5MV4TYP2A7CI4Y46UXF0YGC.md 'Cat\.EventProcessor\.Abstractions\.CatMessageContext\.Begin\(string, int\)') | Sets the current message until the returned object is disposed\. The receiver calls it\. |
