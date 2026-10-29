<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [Cat\.Object\.Extensions](Cat.Object.Extensions.md 'Cat\.Object\.Extensions') > [ObjectExtensions](ObjectExtensions.md 'Cat\.Object\.Extensions\.ObjectExtensions')

## ObjectExtensions\.ThrowIfGreaterThanOrEqualTo Method

| Overloads | |
| :--- | :--- |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)') | Throws if [lowerBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.upperBound'), using [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')'s default comparison\. |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)') | Throws if [lowerBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.upperBound'), using the given comparer\. |

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string)'></a>

## ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\) Method

Throws if [lowerBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.upperBound'), using [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')'s default comparison\.

```csharp
public static void ThrowIfGreaterThanOrEqualTo<T>(this T lowerBound, T upperBound, string lowerBoundName, string upperBoundName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T'></a>

`T`

The type being compared\. Must implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).lowerBound'></a>

`lowerBound` [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')

The value expected to be the lower bound\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).upperBound'></a>

`upperBound` [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')

The value expected to be the upper bound\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).lowerBoundName'></a>

`lowerBoundName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the lower bound to report in the exception\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).upperBoundName'></a>

`upperBoundName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the upper bound to report in the exception\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T') doesn't implement [System\.IComparable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1 'System\.IComparable\`1')\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [lowerBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.upperBound')\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string)'></a>

## ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, IComparer\<T\>, string, string\) Method

Throws if [lowerBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.upperBound'), using the given comparer\.

```csharp
public static void ThrowIfGreaterThanOrEqualTo<T>(this T lowerBound, T upperBound, System.Collections.Generic.IComparer<T> comparer, string lowerBoundName, string upperBoundName);
```
#### Type parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T'></a>

`T`

The type being compared\.
#### Parameters

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).lowerBound'></a>

`lowerBound` [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')

The value expected to be the lower bound\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).upperBound'></a>

`upperBound` [T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')

The value expected to be the upper bound\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[T](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

The comparer to use\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).lowerBoundName'></a>

`lowerBoundName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the lower bound to report in the exception\.

<a name='Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).upperBoundName'></a>

`upperBoundName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the upper bound to report in the exception\.

#### Exceptions

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [lowerBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.upperBound')\.