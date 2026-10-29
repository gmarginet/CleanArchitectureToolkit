<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [Cat\.Object\.Extensions](Cat.Object.Extensions.md 'Cat\.Object\.Extensions') > [ObjectExtensions](ObjectExtensions.md 'Cat\.Object\.Extensions\.ObjectExtensions')

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