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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXPRESSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expressions Assembly](index.md 'index') >> [Cat\.Expressions Namespace](Cat.Expressions.md 'Cat\.Expressions') >> [CatCompiledMemberExpressionCache&lt;T&gt; Class](CatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>')

## CatCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(Expression\<Func\<T,TProperty\>\>, MemberInfo\) Method

Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call\.

```csharp
public System.Func<T,TProperty> GetOrAdd<TProperty>(System.Linq.Expressions.Expression<System.Func<T,TProperty>> expression, System.Reflection.MemberInfo? memberInfo=null);
```
#### Type parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).TProperty'></a>

`TProperty`

The type of value the compiled delegate returns\.
#### Parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](CatCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatCompiledMemberExpressionCache_T_.GetOrAdd.A4EPRTY1L2ENRU10C6Y3UUVA6.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).TProperty 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The member access expression to compile\.

<a name='Cat.Expressions.CatCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).memberInfo'></a>

`memberInfo` [System\.Reflection\.MemberInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo 'System\.Reflection\.MemberInfo')

The member the expression resolves to, if already known\. Pass `null` to let the cache resolve it from the expression\.

Implements [GetOrAdd&lt;TProperty&gt;\(Expression&lt;Func&lt;T,TProperty&gt;&gt;, MemberInfo\)](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.GetOrAdd.2M631FS7ODY5KGI1ED0YSU77A.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1\.GetOrAdd\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Reflection\.MemberInfo\)')

#### Returns
[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](CatCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatCompiledMemberExpressionCache_T_.GetOrAdd.A4EPRTY1L2ENRU10C6Y3UUVA6.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.GetOrAdd_TProperty_(System.Linq.Expressions.Expression_System.Func_T,TProperty__,System.Reflection.MemberInfo).TProperty 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')  
A compiled delegate that evaluates the expression against an instance of [T](CatCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.T')\.