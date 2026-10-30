<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [Cat\.Object\.Extensions](Cat.Object.Extensions.md 'Cat\.Object\.Extensions')

## ObjectExtensions Class

Extension methods for argument validation\.

```csharp
public static class ObjectExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ObjectExtensions

| Methods | |
| :--- | :--- |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)') | Throws if [lowerBound](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.upperBound'), using [T](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,string,string).T 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, string, string\)\.T')'s default comparison\. |
| [ThrowIfGreaterThanOrEqualTo&lt;T&gt;\(this T, T, IComparer&lt;T&gt;, string, string\)](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string) 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)') | Throws if [lowerBound](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).lowerBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.lowerBound') is greater than or equal to [upperBound](ObjectExtensions.ThrowIfGreaterThanOrEqualTo.md#Cat.Object.Extensions.ObjectExtensions.ThrowIfGreaterThanOrEqualTo_T_(thisT,T,System.Collections.Generic.IComparer_T_,string,string).upperBound 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfGreaterThanOrEqualTo\<T\>\(this T, T, System\.Collections\.Generic\.IComparer\<T\>, string, string\)\.upperBound'), using the given comparer\. |
| [ThrowIfNull&lt;T&gt;\(this T, string\)](ObjectExtensions.ThrowIfNull.MYNW4LFAKIED5KYK9Q59F2W41.md 'Cat\.Object\.Extensions\.ObjectExtensions\.ThrowIfNull\<T\>\(this T, string\)') | Returns the argument once confirmed non\-null, otherwise throws\. |
