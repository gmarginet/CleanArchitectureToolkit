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
  
##### >> [Cat\.Expressions Assembly](index.md 'index') >> [Cat\.Expressions Namespace](Cat.Expressions.md 'Cat\.Expressions')

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

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCompiledMemberExpressionCache\<T\>

Implements [Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[T](CatCompiledMemberExpressionCache_T_.md#Cat.Expressions.CatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.T')[&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')

| Fields | |
| :--- | :--- |
| [\_cache](CatCompiledMemberExpressionCache_T_._cache.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.\_cache') | |

| Methods | |
| :--- | :--- |
| [GetOrAdd&lt;TProperty&gt;\(Expression&lt;Func&lt;T,TProperty&gt;&gt;, MemberInfo\)](CatCompiledMemberExpressionCache_T_.GetOrAdd.A4EPRTY1L2ENRU10C6Y3UUVA6.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>\.GetOrAdd\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>, System\.Reflection\.MemberInfo\)') | Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call\. |
