<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expressions\.Abstractions](index.md 'index') > [Cat\.Expressions\.Abstractions](Cat.Expressions.Abstractions.md 'Cat\.Expressions\.Abstractions')

## ICatCompiledMemberExpressionCache\<T\> Interface

Caches compiled member access delegates for [T](ICatCompiledMemberExpressionCache_T_.md#Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<T\>\.T'), so the same expression doesn't get recompiled on every call\.

```csharp
public interface ICatCompiledMemberExpressionCache<T>
    where T : class
```
#### Type parameters

<a name='Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_T_.T'></a>

`T`

The type the member expression is evaluated against\.

| Methods | |
| :--- | :--- |
| [GetOrAdd&lt;TProperty&gt;\(Expression&lt;Func&lt;T,TProperty&gt;&gt;, MemberInfo\)](ICatCompiledMemberExpressionCache_T_.GetOrAdd.2M631FS7ODY5KGI1ED0YSU77A.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)') | Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call\. |
