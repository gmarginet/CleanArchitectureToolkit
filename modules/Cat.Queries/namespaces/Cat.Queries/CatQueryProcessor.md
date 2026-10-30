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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries Assembly](index.md 'index') >> [Cat\.Queries Namespace](Cat.Queries.md 'Cat\.Queries')

## CatQueryProcessor Class

Default [ICatQueryProcessor](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')\.
Opens a new scope per query, gets the decorated handler from it and invokes the handler\.

```csharp
internal class CatQueryProcessor : Cat.Queries.Abstractions.ICatQueryProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryProcessor

Implements [ICatQueryProcessor](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

| Constructors | |
| :--- | :--- |
| [CatQueryProcessor\(IServiceProvider, ICatDecoratorFactory\)](CatQueryProcessor..ctor.ZYV1NSBUVKFC4AJ4TLQSNFX15.md 'Cat\.Queries\.CatQueryProcessor\.CatQueryProcessor\(System\.IServiceProvider, Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_decoratorFactory](CatQueryProcessor._decoratorFactory.md 'Cat\.Queries\.CatQueryProcessor\.\_decoratorFactory') | |
| [\_serviceProvider](CatQueryProcessor._serviceProvider.md 'Cat\.Queries\.CatQueryProcessor\.\_serviceProvider') | |

| Methods | |
| :--- | :--- |
| [InvokeHandler\(MethodInfo, object, object, CancellationToken\)](CatQueryProcessor.InvokeHandler.M6W68CIA01HAMNW1HJY9QNHX4.md 'Cat\.Queries\.CatQueryProcessor\.InvokeHandler\(System\.Reflection\.MethodInfo, object, object, System\.Threading\.CancellationToken\)') | Calls the handler\. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\. |
| [Process&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;\)](CatQueryProcessor.Process.PRKXML2YZUDYVAVA1P70I8YH7.md 'Cat\.Queries\.CatQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)') | Runs a query and blocks until it finishes\. Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\`\`1\(Cat\.Queries\.Abstractions\.ICatQuery\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](CatQueryProcessor.ProcessAsync.E5H8OCSZSVOTZYUV492SO54Y6.md 'Cat\.Queries\.CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') | Runs a query\. |
