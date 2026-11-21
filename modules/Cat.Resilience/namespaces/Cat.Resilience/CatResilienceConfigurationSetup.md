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
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience Namespace](Cat.Resilience.md 'Cat\.Resilience')

## CatResilienceConfigurationSetup Class

Reads the profiles from configuration after the code has set them, so configuration wins over code\.

```csharp
internal sealed class CatResilienceConfigurationSetup : Microsoft.Extensions.Options.IPostConfigureOptions<Cat.Resilience.Abstractions.CatResilienceOptions>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatResilienceConfigurationSetup

Implements [Microsoft\.Extensions\.Options\.IPostConfigureOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ipostconfigureoptions-1 'Microsoft\.Extensions\.Options\.IPostConfigureOptions\`1')[CatResilienceOptions](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ipostconfigureoptions-1 'Microsoft\.Extensions\.Options\.IPostConfigureOptions\`1')

| Constructors | |
| :--- | :--- |
| [CatResilienceConfigurationSetup\(IServiceProvider\)](CatResilienceConfigurationSetup..ctor.ZLV9O8YEM0R1B95ZZ4HICSN14.md 'Cat\.Resilience\.CatResilienceConfigurationSetup\.CatResilienceConfigurationSetup\(System\.IServiceProvider\)') | Reads the profiles from configuration after the code has set them, so configuration wins over code\. |

| Methods | |
| :--- | :--- |
| [PostConfigure\(string, CatResilienceOptions\)](CatResilienceConfigurationSetup.PostConfigure.HGZ2F5LPLV7039WSSPBI3LFR7.md 'Cat\.Resilience\.CatResilienceConfigurationSetup\.PostConfigure\(string, Cat\.Resilience\.Abstractions\.CatResilienceOptions\)') | |
