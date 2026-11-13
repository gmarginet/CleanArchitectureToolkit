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
  
##### >> [Cat\.UnitTesting\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.NUnit Namespace](Cat.UnitTesting.NUnit.md 'Cat\.UnitTesting\.NUnit')

## UnitTestBase Class

Base class for a test fixture that needs a service provider\. It builds the provider once per fixture
from [ConfigureServices\(ServiceCollection\)](UnitTestBase.ConfigureServices.OLU9DG23ZDAWUI1TJW25YK3J4.md 'Cat\.UnitTesting\.NUnit\.UnitTestBase\.ConfigureServices\(Microsoft\.Extensions\.DependencyInjection\.ServiceCollection\)') and disposes it after the last test\.

```csharp
public abstract class UnitTestBase
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → UnitTestBase

| Fields | |
| :--- | :--- |
| [\_serviceProvider](UnitTestBase._serviceProvider.md 'Cat\.UnitTesting\.NUnit\.UnitTestBase\.\_serviceProvider') | |

| Properties | |
| :--- | :--- |
| [ServiceProvider](UnitTestBase.ServiceProvider.md 'Cat\.UnitTesting\.NUnit\.UnitTestBase\.ServiceProvider') | The service provider of the fixture\. It exists from the one time setup on\. |

| Methods | |
| :--- | :--- |
| [BaseOneTimeSetup\(\)](UnitTestBase.BaseOneTimeSetup().md 'Cat\.UnitTesting\.NUnit\.UnitTestBase\.BaseOneTimeSetup\(\)') | Builds the service provider\. NUnit runs it once before the first test of the fixture\. |
| [BaseOneTimeTearDown\(\)](UnitTestBase.BaseOneTimeTearDown().md 'Cat\.UnitTesting\.NUnit\.UnitTestBase\.BaseOneTimeTearDown\(\)') | Disposes the service provider\. NUnit runs it once after the last test of the fixture\. |
| [ConfigureServices\(ServiceCollection\)](UnitTestBase.ConfigureServices.OLU9DG23ZDAWUI1TJW25YK3J4.md 'Cat\.UnitTesting\.NUnit\.UnitTestBase\.ConfigureServices\(Microsoft\.Extensions\.DependencyInjection\.ServiceCollection\)') | Registers the services of the fixture\. |
