<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions') > [CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey')

## CatCompiledMemberExpressionKey\.Equals Method

| Overloads | |
| :--- | :--- |
| [Equals\(CatCompiledMemberExpressionKey\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)') | Checks whether this key refers to the same member and expression text as [other](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)\.other')\. |
| [Equals\(object\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)') | Checks whether [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key that refers to the same member and expression text\. |

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey)'></a>

## CatCompiledMemberExpressionKey\.Equals\(CatCompiledMemberExpressionKey\) Method

Checks whether this key refers to the same member and expression text as [other](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)\.other')\.

```csharp
public bool Equals(Cat.Expressions.CatCompiledMemberExpressionKey other);
```
#### Parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other'></a>

`other` [CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey')

The key to compare against\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if both keys refer to the same member and expression text\.

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object)'></a>

## CatCompiledMemberExpressionKey\.Equals\(object\) Method

Checks whether [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key that refers to the same member and expression text\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare against\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key with the same member and expression text\.