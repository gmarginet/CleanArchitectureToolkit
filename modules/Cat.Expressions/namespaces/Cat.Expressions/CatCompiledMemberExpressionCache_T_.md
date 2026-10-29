<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions')

## CatCompiledMemberExpressionCache\<T\> Class

Caches compiled member expressions in a concurrent dictionary, keyed by member and expression text, so the
same expression is compiled only once\.

```csharp
internal class CatCompiledMemberExpressionCache<T> : Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache<T>
    where T : class
```
#### Type parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionCache_T_.T'></a>

`T`

The type the member expression is evaluated against\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatCompiledMemberExpressionCache\<T\>

Implements [Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[T](CatCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.T')[&gt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')

| Fields | |
| :--- | :--- |
| [\_cache](CatCompiledMemberExpressionCache_T_._cache.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.\_cache') | |

| Methods | |
| :--- | :--- |
| [GetOrAdd&lt;TProperty&gt;\(Expression&lt;Func&lt;T,TProperty&gt;&gt;, MemberInfo\)](CatCompiledMemberExpressionCache_T_.GetOrAdd.A4EPRTY1L2ENRU10C6Y3UUVA6.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)') | Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call\. |
