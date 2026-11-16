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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Extensions\.Objects Assembly](index.md 'index') >> [Cat\.Extensions\.Objects Namespace](Cat.Extensions.Objects.md 'Cat\.Extensions\.Objects') >> [ObjectExtensions Class](ObjectExtensions.md 'Cat\.Extensions\.Objects\.ObjectExtensions')

## ObjectExtensions\.CompareDefault\<T\>\(T, T\) Method

Compares two values using [T](ObjectExtensions.CompareDefault.Z0UUD76VS747J0TLHXZLFFRT8.md#Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)\.T')'s default comparison\.

```csharp
private static int CompareDefault<T>(T value, T other);
```
#### Type parameters

<a name='Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).T'></a>

`T`

The type being compared\. Must implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.
#### Parameters

<a name='Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).value'></a>

`value` [T](ObjectExtensions.CompareDefault.Z0UUD76VS747J0TLHXZLFFRT8.md#Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)\.T')

The value to compare\.

<a name='Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).other'></a>

`other` [T](ObjectExtensions.CompareDefault.Z0UUD76VS747J0TLHXZLFFRT8.md#Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)\.T')

The value to compare with\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A negative number when [value](ObjectExtensions.CompareDefault.Z0UUD76VS747J0TLHXZLFFRT8.md#Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)\.value') is lower, zero when they are equal, a positive number when it is higher\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [T](ObjectExtensions.CompareDefault.Z0UUD76VS747J0TLHXZLFFRT8.md#Cat.Extensions.Objects.ObjectExtensions.CompareDefault_T_(T,T).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)\.T') doesn't implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.