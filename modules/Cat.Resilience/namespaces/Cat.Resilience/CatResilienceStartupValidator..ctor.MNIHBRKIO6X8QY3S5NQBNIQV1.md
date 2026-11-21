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
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience Namespace](Cat.Resilience.md 'Cat\.Resilience') >> [CatResilienceStartupValidator Class](CatResilienceStartupValidator.md 'Cat\.Resilience\.CatResilienceStartupValidator')

## CatResilienceStartupValidator\(IEnumerable\<CatResilienceUse\>, CatResilienceProfiles\) Constructor

Fails the startup of the host when a registration refers to a profile that does not exist\.

```csharp
public CatResilienceStartupValidator(System.Collections.Generic.IEnumerable<Cat.Resilience.CatResilienceUse> uses, Cat.Resilience.CatResilienceProfiles profiles);
```
#### Parameters

<a name='Cat.Resilience.CatResilienceStartupValidator.CatResilienceStartupValidator(System.Collections.Generic.IEnumerable_Cat.Resilience.CatResilienceUse_,Cat.Resilience.CatResilienceProfiles).uses'></a>

`uses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[CatResilienceUse](CatResilienceUse.md 'Cat\.Resilience\.CatResilienceUse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='Cat.Resilience.CatResilienceStartupValidator.CatResilienceStartupValidator(System.Collections.Generic.IEnumerable_Cat.Resilience.CatResilienceUse_,Cat.Resilience.CatResilienceProfiles).profiles'></a>

`profiles` [CatResilienceProfiles](CatResilienceProfiles.md 'Cat\.Resilience\.CatResilienceProfiles')