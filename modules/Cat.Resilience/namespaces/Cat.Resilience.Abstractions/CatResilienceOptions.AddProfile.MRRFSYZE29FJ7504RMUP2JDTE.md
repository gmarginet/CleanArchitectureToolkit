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
  
##### >> [Cat\.Resilience\.Abstractions Assembly](index.md 'index') >> [Cat\.Resilience\.Abstractions Namespace](Cat.Resilience.Abstractions.md 'Cat\.Resilience\.Abstractions') >> [CatResilienceOptions Class](CatResilienceOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceOptions')

## CatResilienceOptions\.AddProfile\(string, Action\<CatResilienceProfileOptions\>\) Method

Adds a profile, or changes the profile of that name when it exists\. A new profile starts with the defaults of the
[Internal](CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal') profile\.

```csharp
public Cat.Resilience.Abstractions.CatResilienceOptions AddProfile(string name, System.Action<Cat.Resilience.Abstractions.CatResilienceProfileOptions> configure);
```
#### Parameters

<a name='Cat.Resilience.Abstractions.CatResilienceOptions.AddProfile(string,System.Action_Cat.Resilience.Abstractions.CatResilienceProfileOptions_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the profile\.

<a name='Cat.Resilience.Abstractions.CatResilienceOptions.AddProfile(string,System.Action_Cat.Resilience.Abstractions.CatResilienceProfileOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatResilienceProfileOptions](CatResilienceProfileOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfileOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the settings of the profile\.

#### Returns
[CatResilienceOptions](CatResilienceOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceOptions')  
The same options, for chaining\.