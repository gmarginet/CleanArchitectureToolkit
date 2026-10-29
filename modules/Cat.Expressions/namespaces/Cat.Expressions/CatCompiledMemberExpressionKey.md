<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions')

## CatCompiledMemberExpressionKey Class

Identifies a compiled member expression by its member and the expression's text, so it can be used as a cache key\.

```csharp
internal class CatCompiledMemberExpressionKey
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatCompiledMemberExpressionKey

| Constructors | |
| :--- | :--- |
| [CatCompiledMemberExpressionKey\(MemberInfo, Expression\)](CatCompiledMemberExpressionKey..ctor.2MT4S8DKD3ICHY8XPI3VJOY1B.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.CatCompiledMemberExpressionKey\(System\.Reflection\.MemberInfo, System\.Linq\.Expressions\.Expression\)') | Captures the member and the expression's string form, so two keys built from equivalent expressions compare equal\. |

| Fields | |
| :--- | :--- |
| [\_expressionKey](CatCompiledMemberExpressionKey._expressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.\_expressionKey') | |
| [\_memberInfo](CatCompiledMemberExpressionKey._memberInfo.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.\_memberInfo') | |

| Methods | |
| :--- | :--- |
| [Equals\(CatCompiledMemberExpressionKey\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)') | Checks whether this key refers to the same member and expression text as [other](CatCompiledMemberExpressionKey.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)\.other')\. |
| [Equals\(object\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)') | Determines whether the specified object is equal to the current object\. |
| [GetHashCode\(\)](CatCompiledMemberExpressionKey.GetHashCode().md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.GetHashCode\(\)') | Serves as the default hash function\. |
