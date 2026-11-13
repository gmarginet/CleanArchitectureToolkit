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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SCHEDULING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Scheduling\.Abstractions Assembly](index.md 'index') >> [Cat\.Scheduling\.Abstractions Namespace](Cat.Scheduling.Abstractions.md 'Cat\.Scheduling\.Abstractions')

## CatJobRegistration Class

A declared job: a name, the service request to send and the settings\.

```csharp
public class CatJobRegistration
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobRegistration

| Constructors | |
| :--- | :--- |
| [CatJobRegistration\(string, Func&lt;ICatServiceRequest&gt;, CatJobOptions\)](CatJobRegistration..ctor.S6WVB6L2NC6J51UZSNJW6D437.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration\.CatJobRegistration\(string, System\.Func\<Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\>, Cat\.Scheduling\.Abstractions\.CatJobOptions\)') | Creates a registration\. |

| Properties | |
| :--- | :--- |
| [Name](CatJobRegistration.Name.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration\.Name') | The name of the job\. |
| [Options](CatJobRegistration.Options.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration\.Options') | The settings of the job\. |
| [RequestFactory](CatJobRegistration.RequestFactory.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration\.RequestFactory') | Creates the service request for a run\. It is called once for every run\. |
