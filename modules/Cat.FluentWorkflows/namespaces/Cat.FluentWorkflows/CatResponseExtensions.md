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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions')

## CatResponseExtensions Class

Turns a response of a command, a query or a service request into a workflow response\.

```csharp
public static class CatResponseExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatResponseExtensions

| Methods | |
| :--- | :--- |
| [Cast\(this ICatResponse, CatStepExecutionResult\)](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\(this Cat\.Responses\.Abstractions\.ICatResponse, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Turns a response into a workflow response\. The errors of a failed response come along\. |
| [Cast&lt;TSource&gt;\(this ICatResponse&lt;TSource&gt;, CatStepExecutionResult\)](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\<TSource\>\(this Cat\.Responses\.Abstractions\.ICatResponse\<TSource\>, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Turns a response with a payload into a workflow response\. The payload is dropped and the errors of a failed response come along\. |
