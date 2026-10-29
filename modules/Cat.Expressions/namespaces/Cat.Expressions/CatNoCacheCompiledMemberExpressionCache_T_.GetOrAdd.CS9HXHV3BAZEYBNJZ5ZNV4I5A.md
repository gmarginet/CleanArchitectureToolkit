<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions') > [CatNoCacheCompiledMemberExpressionCache&lt;T&gt;](CatNoCacheCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>')

## CatNoCacheCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(Expression\<Func\<T,TProperty\>\>, MemberInfo\) Method

Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call\.

```csharp
public System.Func<T,TProperty> GetOrAdd<TProperty>(System.Linq.Expressions.Expression<System.Func<T,TProperty>> expression, System.Reflection.MemberInfo? memberInfo=null);
```
#### Type parameters

<a name='Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).TProperty'></a>

`TProperty`

The type of value the compiled delegate returns\.
#### Parameters

<a name='Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](CatNoCacheCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd.CS9HXHV3BAZEYBNJZ5ZNV4I5A.md#Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).TProperty 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The member access expression to compile\.

<a name='Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).memberInfo'></a>

`memberInfo` [System\.Reflection\.MemberInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo 'System\.Reflection\.MemberInfo')

The member the expression resolves to, if already known\. Pass `null` to let the cache resolve it from the expression\.

Implements [GetOrAdd&lt;TProperty&gt;\(Expression&lt;Func&lt;T,TProperty&gt;&gt;, MemberInfo\)](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.GetOrAdd.2M631FS7ODY5KGI1ED0YSU77A.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1\.GetOrAdd\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Reflection\.MemberInfo\)')

#### Returns
[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](CatNoCacheCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd.CS9HXHV3BAZEYBNJZ5ZNV4I5A.md#Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).TProperty 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')  
A compiled delegate that evaluates the expression against an instance of [T](CatNoCacheCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatNoCacheCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>\.T')\.