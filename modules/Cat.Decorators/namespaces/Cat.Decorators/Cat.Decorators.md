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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators Assembly](index.md 'index')

## Cat\.Decorators Namespace

Provides the default decorator factory and builder\.
They wrap an open generic service in the decorators you registered, in registration order\.

| Classes | |
| :--- | :--- |
| [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory') | Default [ICatDecoratorFactory](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')\. Gets the service from the service provider, then wraps it in each registered decorator in registration order\. |
| [CatDecoratorFactoryBuilder](CatDecoratorFactoryBuilder.md 'Cat\.Decorators\.CatDecoratorFactoryBuilder') | Default [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\. Hands the decorators over to the [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')\. |
| [CatDecoratorInfo](CatDecoratorInfo.md 'Cat\.Decorators\.CatDecoratorInfo') | Describes one registered decorator: its open generic type and the constructor values to pass to it\. |
| [CatDecoratorParameter](CatDecoratorParameter.md 'Cat\.Decorators\.CatDecoratorParameter') | Default [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')\. |
