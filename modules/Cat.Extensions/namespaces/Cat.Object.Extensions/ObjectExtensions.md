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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [Cat\.Object\.Extensions Namespace](Cat.Object.Extensions.md 'Cat\.Object\.Extensions')

## ObjectExtensions Class

Extension methods for argument validation\.

```csharp
public static class ObjectExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ObjectExtensions

| Methods | |
| :--- | :--- |
| [CompareDefault&lt;T&gt;\(T, T\)](ObjectExtensions.CompareDefault.Y1OZYS98CPNWW2Y5QYRJ2WNOD.md 'Cat\.Object\.Extensions\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)') | Compares two values using [T](ObjectExtensions.CompareDefault.Y1OZYS98CPNWW2Y5QYRJ2WNOD.md#Cat.Object.Extensions.ObjectExtensions.CompareDefault_T_(T,T).T 'Cat\.Object\.Extensions\.ObjectExtensions\.CompareDefault\<T\>\(T, T\)\.T')'s default comparison\. |
| [ThrowIfGreaterThan&lt;T&gt;\(this T, T, string\)](ObjectExtensions.ThrowIfGreaterThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThan_T_(thisT,T,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThan\<T\>\(this T, T, string\)') | Returns the value once confirmed to be at most [maximum](ObjectExtensions.ThrowIfGreaterThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThan_T_(thisT,T,string).maximum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThan\<T\>\(this T, T, string\)\.maximum'), otherwise throws\. |
| [ThrowIfGreaterThan&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string\)](ObjectExtensions.ThrowIfGreaterThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)') | Returns the value once confirmed to be at most [maximum](ObjectExtensions.ThrowIfGreaterThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).maximum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.maximum'), otherwise throws\. Uses the given comparer\. |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)') | Returns the value once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.limit'), otherwise throws\. |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)') | Returns the value once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.limit'), otherwise throws\. Uses the given comparer\. |
| [ThrowIfLessThan&lt;T&gt;\(this T, T, string\)](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)') | Returns the value once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.minimum'), otherwise throws\. |
| [ThrowIfLessThan&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string\)](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)') | Returns the value once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.minimum'), otherwise throws\. Uses the given comparer\. |
| [ThrowIfLessThanOrEqualTo&lt;T&gt;\(this T, T, string\)](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)') | Returns the value once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.limit'), otherwise throws\. |
| [ThrowIfLessThanOrEqualTo&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string\)](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)') | Returns the value once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.limit'), otherwise throws\. Uses the given comparer\. |
| [ThrowIfNull&lt;T&gt;\(this T, string\)](ObjectExtensions.ThrowIfNull.MYNW4LFAKIED5KYK9Q59F2W41.md 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\)') | Returns the argument once confirmed non\-null, otherwise throws\. |
