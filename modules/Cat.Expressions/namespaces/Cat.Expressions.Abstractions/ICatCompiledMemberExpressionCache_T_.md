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
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXPRESSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expressions\.Abstractions Assembly](index.md 'index') >> [Cat\.Expressions\.Abstractions Namespace](Cat.Expressions.Abstractions.md 'Cat\.Expressions\.Abstractions')

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
