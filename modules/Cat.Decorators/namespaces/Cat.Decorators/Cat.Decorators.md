<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index')

## Cat\.Decorators Namespace

Provides the default decorator factory and builder\.
They wrap an open generic service in the decorators you registered, in registration order\.

| Classes | |
| :--- | :--- |
| [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory') | Default [ICatDecoratorFactory](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')\. Gets the service from the service provider, then wraps it in each registered decorator in registration order\. |
| [CatDecoratorFactoryBuilder](CatDecoratorFactoryBuilder.md 'Cat\.Decorators\.CatDecoratorFactoryBuilder') | Default [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\. Hands the decorators over to the [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')\. |
| [CatDecoratorInfo](CatDecoratorInfo.md 'Cat\.Decorators\.CatDecoratorInfo') | Describes one registered decorator: its open generic type and the constructor values to pass to it\. |
| [CatDecoratorParameter](CatDecoratorParameter.md 'Cat\.Decorators\.CatDecoratorParameter') | Default [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')\. |
