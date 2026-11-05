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
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [Cat\.Object\.Extensions Namespace](Cat.Object.Extensions.md 'Cat\.Object\.Extensions') >> [ObjectExtensions Class](ObjectExtensions.md 'Cat\.Object\.Extensions\.ObjectExtensions')

## ObjectExtensions\.ThrowIfLessThan Method

| Overloads | |
| :--- | :--- |
| [ThrowIfLessThan&lt;T&gt;\(this T, T, string\)](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)') | Returns the value once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.minimum'), otherwise throws\. |
| [ThrowIfLessThan&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string\)](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)') | Returns the value once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.minimum'), otherwise throws\. Uses the given comparer\. |

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string)'></a>

## ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\) Method

Returns the value once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.minimum'), otherwise throws\.

```csharp
public static T ThrowIfLessThan<T>(this T value, T minimum, string paramName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).T'></a>

`T`

The type being compared\. Must implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).value'></a>

`value` [T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.T')

The value to check\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).minimum'></a>

`minimum` [T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.T')

The lowest value that is allowed\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).paramName'></a>

`paramName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.T')  
[value](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.value'), once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.minimum')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.T') doesn't implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [value](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.value') is less than [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, string\)\.minimum')\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string)'></a>

## ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, IComparer\<T\>, string\) Method

Returns the value once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.minimum'), otherwise throws\. Uses the given comparer\.

```csharp
public static T ThrowIfLessThan<T>(this T value, T minimum, System.Collections.Generic.IComparer<T> comparer, string paramName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T'></a>

`T`

The type being compared\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value'></a>

`value` [T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')

The value to check\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).minimum'></a>

`minimum` [T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')

The lowest value that is allowed\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).paramName'></a>

`paramName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')  
[value](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.value'), once confirmed to be at least [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.minimum')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [value](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.value') is less than [minimum](ObjectExtensions.ThrowIfLessThan.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfLessThan_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).minimum 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfLessThan\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.minimum')\.