<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators\.Abstractions](index.md 'index')

## Cat\.Decorators\.Abstractions Namespace

Defines the contracts for decorators: the factory that returns a decorated service,
the builder that registers decorators, and the parameters you can pass to a decorator\.

| Interfaces | |
| :--- | :--- |
| [ICatDecoratorFactory](ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory') | Gets a service wrapped in the decorators registered for it\. The service type must be a closed generic type, like `IHandler<MyRequest>`\. |
| [ICatDecoratorFactoryBuilder](ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder') | Registers decorators for open generic services\. |
| [ICatDecoratorParameter](ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter') | A fixed value for one constructor parameter of a decorator\. |
