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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators\.Abstractions Assembly](index.md 'index') >> [Cat\.Decorators\.Abstractions Namespace](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions')

## CatDecoratorOrder Class

The default order of the decorators, from the outside in\. A lower number runs first on the way in and last on the way out\.
Every module that ships a decorator uses one of these numbers as its default, so the order is the same
whatever the sequence in which you add the decorators\.
The numbers are spaced out in steps of 100, so you can slot a decorator of your own in between, for example 250\.

```csharp
public static class CatDecoratorOrder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDecoratorOrder

| Fields | |
| :--- | :--- |
| [Default](CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default') | The number of a decorator that is added without an order, after validation\. It sees valid input\. |
| [Logging](CatDecoratorOrder.Logging.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Logging') | Logging\. It logs every request, also the ones that validation turns down\. |
| [Tracing](CatDecoratorOrder.Tracing.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Tracing') | Tracing, the outermost decorator\. It sees every request, so the trace covers all the other work\. |
| [Validation](CatDecoratorOrder.Validation.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Validation') | Validation\. It lets only valid requests through to the decorators and the handler that follow\. |
