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
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [Cat\.Object\.Extensions Namespace](Cat.Object.Extensions.md 'Cat\.Object\.Extensions') >> [ObjectExtensions Class](ObjectExtensions.md 'Cat\.Object\.Extensions\.ObjectExtensions')

## ObjectExtensions\.ThrowIfGreaterThanOrEqualTo Method

| Overloads | |
| :--- | :--- |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)') | Returns the value once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.limit'), otherwise throws\. |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)') | Returns the value once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.limit'), otherwise throws\. Uses the given comparer\. |

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string)'></a>

## ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\) Method

Returns the value once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.limit'), otherwise throws\.

```csharp
public static T ThrowIfGreaterThanOrEqualTo<T>(this T value, T limit, string valueName, string limitName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T'></a>

`T`

The type being compared\. Must implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).value'></a>

`value` [T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')

The value to check\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit'></a>

`limit` [T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')

The value that [value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.value') must be less than\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).valueName'></a>

`valueName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of [value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.value') to report in the exception\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limitName'></a>

`limitName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.limit') to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')  
[value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.value'), once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.limit')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T') doesn't implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.value') is greater than or equal to [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.limit')\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string)'></a>

## ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, IComparer\<T\>, string, string\) Method

Returns the value once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.limit'), otherwise throws\. Uses the given comparer\.

```csharp
public static T ThrowIfGreaterThanOrEqualTo<T>(this T value, T limit, System.Collections.Generic.IComparer<T> comparer, string valueName, string limitName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T'></a>

`T`

The type being compared\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).value'></a>

`value` [T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')

The value to check\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit'></a>

`limit` [T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')

The value that [value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.value') must be less than\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).valueName'></a>

`valueName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of [value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.value') to report in the exception\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limitName'></a>

`limitName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.limit') to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')  
[value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.value'), once confirmed to be less than [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.limit')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [value](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).value 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.value') is greater than or equal to [limit](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).limit 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.limit')\.