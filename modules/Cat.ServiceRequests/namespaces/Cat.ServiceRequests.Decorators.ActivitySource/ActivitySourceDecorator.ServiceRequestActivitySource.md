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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Namespace](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') >> [ActivitySourceDecorator Class](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator')

## ActivitySourceDecorator\.ServiceRequestActivitySource Class

Owns the shared [System\.Diagnostics\.ActivitySource](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activitysource 'System\.Diagnostics\.ActivitySource') named "Cat\.ServiceRequests"\.

```csharp
private static class ActivitySourceDecorator.ServiceRequestActivitySource
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceRequestActivitySource

| Constructors | |
| :--- | :--- |
| [ServiceRequestActivitySource\(\)](ActivitySourceDecorator.ServiceRequestActivitySource.ServiceRequestActivitySource().md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource\.ServiceRequestActivitySource\(\)') | |

| Fields | |
| :--- | :--- |
| [ActivitySourceName](ActivitySourceDecorator.ServiceRequestActivitySource.ActivitySourceName.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource\.ActivitySourceName') | |
| [Instance](ActivitySourceDecorator.ServiceRequestActivitySource.Instance.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource\.Instance') | |

| Methods | |
| :--- | :--- |
| [CreateActivity\(string\)](ActivitySourceDecorator.ServiceRequestActivitySource.CreateActivity.J5GLL3BTX0IE2RN3SDKQIV5ID.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource\.CreateActivity\(string\)') | Starts a client activity\. |
