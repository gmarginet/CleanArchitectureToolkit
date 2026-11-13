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
  
##### >> [Cat\.UnitTesting\.Responses\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.Responses\.NUnit Namespace](Cat.UnitTesting.Responses.NUnit.md 'Cat\.UnitTesting\.Responses\.NUnit') >> [CatResponseConstraint Class](CatResponseConstraint.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint')

## CatResponseConstraint\.ApplyTo\<TActual\>\(TActual\) Method

Applies the constraint to an actual value, returning a ConstraintResult\.

```csharp
public override NUnit.Framework.Constraints.ConstraintResult ApplyTo<TActual>(TActual actual);
```
#### Type parameters

<a name='Cat.UnitTesting.Responses.NUnit.CatResponseConstraint.ApplyTo_TActual_(TActual).TActual'></a>

`TActual`
#### Parameters

<a name='Cat.UnitTesting.Responses.NUnit.CatResponseConstraint.ApplyTo_TActual_(TActual).actual'></a>

`actual` [TActual](CatResponseConstraint.ApplyTo.T1T6N5ZEYC79BNKM1YJ0FBEY2.md#Cat.UnitTesting.Responses.NUnit.CatResponseConstraint.ApplyTo_TActual_(TActual).TActual 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint\.ApplyTo\<TActual\>\(TActual\)\.TActual')

The value to be tested

Implements [ApplyTo&lt;TActual&gt;\(TActual\)](https://learn.microsoft.com/en-us/dotnet/api/nunit.framework.constraints.iconstraint.applyto--1#nunit-framework-constraints-iconstraint-applyto--1(--0) 'NUnit\.Framework\.Constraints\.IConstraint\.ApplyTo\`\`1\(\`\`0\)')

#### Returns
[NUnit\.Framework\.Constraints\.ConstraintResult](https://learn.microsoft.com/en-us/dotnet/api/nunit.framework.constraints.constraintresult 'NUnit\.Framework\.Constraints\.ConstraintResult')  
A ConstraintResult