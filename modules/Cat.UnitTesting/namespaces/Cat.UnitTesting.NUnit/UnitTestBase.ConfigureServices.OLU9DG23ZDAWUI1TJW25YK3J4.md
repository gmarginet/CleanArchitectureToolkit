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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.NUnit Namespace](Cat.UnitTesting.NUnit.md 'Cat\.UnitTesting\.NUnit') >> [UnitTestBase Class](UnitTestBase.md 'Cat\.UnitTesting\.NUnit\.UnitTestBase')

## UnitTestBase\.ConfigureServices\(ServiceCollection\) Method

Registers the services of the fixture\.

```csharp
protected abstract void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services);
```
#### Parameters

<a name='Cat.UnitTesting.NUnit.UnitTestBase.ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.ServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicecollection 'Microsoft\.Extensions\.DependencyInjection\.ServiceCollection')

The collection to register the services in\.