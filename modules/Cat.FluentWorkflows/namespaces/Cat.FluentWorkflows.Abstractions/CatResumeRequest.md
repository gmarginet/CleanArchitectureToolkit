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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Abstractions Namespace](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## CatResumeRequest Class

The answer of a resume and the step it is meant for\. All the levels of one resume share the same request\.

```csharp
public sealed class CatResumeRequest
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatResumeRequest

| Constructors | |
| :--- | :--- |
| [CatResumeRequest\(object, string\)](CatResumeRequest..ctor.63G7OB9KC9M94GG26OPIQGFK4.md 'Cat\.FluentWorkflows\.Abstractions\.CatResumeRequest\.CatResumeRequest\(object, string\)') | Creates the request\. |

| Properties | |
| :--- | :--- |
| [Answer](CatResumeRequest.Answer.md 'Cat\.FluentWorkflows\.Abstractions\.CatResumeRequest\.Answer') | The answer for the waiting step\. |
| [Target](CatResumeRequest.Target.md 'Cat\.FluentWorkflows\.Abstractions\.CatResumeRequest\.Target') | The name of the waiting step that gets the answer, or `null` when only one step waits\. |

| Methods | |
| :--- | :--- |
| [IsMeantFor\(CatCheckpointFrame\)](CatResumeRequest.IsMeantFor.D3IJCAC0GH80EAKJYMQSJXSX9.md 'Cat\.FluentWorkflows\.Abstractions\.CatResumeRequest\.IsMeantFor\(Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\)') | Checks if a frame holds the step that gets the answer, at any depth\. |
