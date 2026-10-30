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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the fluent workflows module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatFluentWorkflowsFlows\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatFluentWorkflowsFlows.E0KTFKVUMXI85V5BSUOTEJAQ6.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions\.AddCatFluentWorkflowsFlows\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers every workflow found in the given assemblies, with a transient lifetime\. Only public classes that are not generic are registered\. |
| [AddCatFluentWorkflowsModule\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatFluentWorkflowsModule.XAL21HCPDBGRTJVEFQRFIRMQE.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions\.AddCatFluentWorkflowsModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers the workflow and step processors and every built\-in step\. |
| [AddCatFluentWorkflowsSteps\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatFluentWorkflowsSteps.MOU9BI7E0SJF8KRDQ0LTX9MR.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions\.AddCatFluentWorkflowsSteps\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers every step body found in the given assemblies, with a transient lifetime\. Only public classes that are not generic are registered\. |
