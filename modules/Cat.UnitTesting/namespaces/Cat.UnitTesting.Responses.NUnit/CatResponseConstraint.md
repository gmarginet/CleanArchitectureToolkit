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
  
##### >> [Cat\.UnitTesting\.Responses\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.Responses\.NUnit Namespace](Cat.UnitTesting.Responses.NUnit.md 'Cat\.UnitTesting\.Responses\.NUnit')

## CatResponseConstraint Class

A constraint that checks the outcome, the type and an error code of an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\.
Create it with [CatIs](CatIs.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs')\. A failed check shows the response as it is, for example `Failed NotFound [DEM-ORD-1004]`\.

```csharp
public sealed class CatResponseConstraint : NUnit.Framework.Constraints.Constraint
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [NUnit\.Framework\.Constraints\.Constraint](https://learn.microsoft.com/en-us/dotnet/api/nunit.framework.constraints.constraint 'NUnit\.Framework\.Constraints\.Constraint') → CatResponseConstraint

| Constructors | |
| :--- | :--- |
| [CatResponseConstraint\(bool, CatResponseType, string\)](CatResponseConstraint..ctor.C7J63VZ0RMVWBFWOQGBDYTRFC.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.CatResponseConstraint\(bool, Cat\.Responses\.Abstractions\.CatResponseType, string\)') | Creates the constraint\. |

| Fields | |
| :--- | :--- |
| [\_errorCode](CatResponseConstraint._errorCode.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.\_errorCode') | |
| [\_succeeded](CatResponseConstraint._succeeded.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.\_succeeded') | |
| [\_type](CatResponseConstraint._type.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.\_type') | |

| Properties | |
| :--- | :--- |
| [Description](CatResponseConstraint.Description.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.Description') | The Description of what this constraint tests, for use in messages and in the ConstraintResult\. |

| Methods | |
| :--- | :--- |
| [ApplyTo&lt;TActual&gt;\(TActual\)](CatResponseConstraint.ApplyTo.T1T6N5ZEYC79BNKM1YJ0FBEY2.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.ApplyTo\<TActual\>\(TActual\)') | Applies the constraint to an actual value, returning a ConstraintResult\. |
| [Describe\(ICatResponse\)](CatResponseConstraint.Describe.4YEG11RBG5755SCBOSMLB6Y74.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.Describe\(Cat\.Responses\.Abstractions\.ICatResponse\)') | |
