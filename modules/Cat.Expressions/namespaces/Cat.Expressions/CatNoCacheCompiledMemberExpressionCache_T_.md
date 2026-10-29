<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions')

## CatNoCacheCompiledMemberExpressionCache\<T\> Class

Compiles a member expression into a delegate on every call, without caching the result\.
Use this when caching isn't worth it, for example when expressions are built fresh each time anyway\.

```csharp
public class CatNoCacheCompiledMemberExpressionCache<T> : Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache<T>
    where T : class
```
#### Type parameters

<a name='Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.T'></a>

`T`

The type the member expression is evaluated against\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatNoCacheCompiledMemberExpressionCache\<T\>

Implements [Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[T](CatNoCacheCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.T')[&gt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')

| Methods | |
| :--- | :--- |
| [GetOrAdd&lt;TProperty&gt;\(Expression&lt;Func&lt;T,TProperty&gt;&gt;, MemberInfo\)](CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd.CS9HXHV3BAZEYBNJZ5ZNV4I5A.md 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)') | Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call\. |
