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

## ObjectExtensions\.ThrowIfLessThanOrEqualTo Method

| Overloads | |
| :--- | :--- |
| [ThrowIfLessThanOrEqualTo&lt;T&gt;\(this T, T, string\)](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string) 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)') | Returns the value once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.limit'), otherwise throws\. |
| [ThrowIfLessThanOrEqualTo&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string\)](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string) 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)') | Returns the value once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.limit'), otherwise throws\. Uses the given comparer\. |

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string)'></a>

## ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\) Method

Returns the value once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.limit'), otherwise throws\.

```csharp
public static T ThrowIfLessThanOrEqualTo<T>(this T value, T limit, string paramName);
```
#### Type parameters

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).T'></a>

`T`

The type being compared\. Must implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.
#### Parameters

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).value'></a>

`value` [T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.T')

The value to check\.

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).limit'></a>

`limit` [T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.T')

The value that [value](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.value') must be higher than\.

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).paramName'></a>

`paramName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.T')  
[value](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.value'), once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.limit')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.T') doesn't implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [value](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.value') is less than or equal to [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, string\)\.limit')\.

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string)'></a>

## ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, IComparer\<T\>, string\) Method

Returns the value once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.limit'), otherwise throws\. Uses the given comparer\.

```csharp
public static T ThrowIfLessThanOrEqualTo<T>(this T value, T limit, System.Collections.Generic.IComparer<T> comparer, string paramName);
```
#### Type parameters

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T'></a>

`T`

The type being compared\.
#### Parameters

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value'></a>

`value` [T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')

The value to check\.

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).limit'></a>

`limit` [T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')

The value that [value](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.value') must be higher than\.

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use\.

<a name='Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).paramName'></a>

`paramName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter to report in the exception\.

#### Returns
[T](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).T 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.T')  
[value](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.value'), once confirmed to be higher than [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.limit')\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [value](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).value 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.value') is less than or equal to [limit](ObjectExtensions.ThrowIfLessThanOrEqualTo.md#Cat.Extensions.Objects.ObjectExtensions.ThrowIfLessThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string).limit 'Cat\.Extensions\.Objects\.ObjectExtensions\.ThrowIfLessThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string\)\.limit')\.