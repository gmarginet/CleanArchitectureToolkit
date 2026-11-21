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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience\.Commands Assembly](index.md 'index') >> [Cat\.Resilience\.Commands\.Extensions Namespace](Cat.Resilience.Commands.Extensions.md 'Cat\.Resilience\.Commands\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the retry around the command processor\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatCommandRetry\(this IServiceCollection, Action&lt;CatCommandRetryOptions&gt;\)](ServiceCollectionExtensions.AddCatCommandRetry.Q1D2KYE56X3ZON2S5SY2M4852.md 'Cat\.Resilience\.Commands\.Extensions\.ServiceCollectionExtensions\.AddCatCommandRetry\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Resilience\.Commands\.CatCommandRetryOptions\>\)') | Retries the command types that you list, through a resilience profile, with a fresh scope for every try\. Register the commands module with `AddCatCommandsModule` and the resilience module with `AddCatResilienceModule` first, because the processor is wrapped and the pipelines come from there\. `ICatCurrentScopeCommandProcessor` is not wrapped, because it runs in the current scope on purpose\. |
| [CreateInner\(IServiceProvider, ServiceDescriptor\)](ServiceCollectionExtensions.CreateInner.TEJXT8U66DY2LI66O7I1S7HZ7.md 'Cat\.Resilience\.Commands\.Extensions\.ServiceCollectionExtensions\.CreateInner\(System\.IServiceProvider, Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor\)') | |
