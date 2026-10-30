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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [Cat\.Object\.Extensions Namespace](Cat.Object.Extensions.md 'Cat\.Object\.Extensions') >> [ObjectExtensions Class](ObjectExtensions.md 'Cat\.Object\.Extensions\.ObjectExtensions')

## ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\) Method

Returns the argument once confirmed non\-null, otherwise throws\.

```csharp
public static T ThrowIfNull<T>(this T? argument, string paramName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).T'></a>

`T`

The type of the argument\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).argument'></a>

`argument` [T](ObjectExtensions.ThrowIfNull.MYNW4LFAKIED5KYK9Q59F2W41.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\)\.T')

The argument to check\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).paramName'></a>

`paramName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfNull.MYNW4LFAKIED5KYK9Q59F2W41.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\)\.T')  
[argument](ObjectExtensions.ThrowIfNull.MYNW4LFAKIED5KYK9Q59F2W41.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).argument 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\)\.argument'), once confirmed non\-null\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [argument](ObjectExtensions.ThrowIfNull.MYNW4LFAKIED5KYK9Q59F2W41.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfNull_T_(thisT,string).argument 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\)\.argument') is `null`\.