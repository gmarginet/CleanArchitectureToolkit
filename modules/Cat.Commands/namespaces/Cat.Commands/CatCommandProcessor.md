<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands](index.md 'index') > [Cat\.Commands](Cat.Commands.md 'Cat\.Commands')

## CatCommandProcessor Class

Default [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')\.
Opens a new scope per command, gets the decorated handler from it and invokes the handler\.

```csharp
internal class CatCommandProcessor : Cat.Commands.Abstractions.ICatCommandProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatCommandProcessor

Implements [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

| Constructors | |
| :--- | :--- |
| [CatCommandProcessor\(IServiceProvider, ICatDecoratorFactory\)](CatCommandProcessor..ctor.BHLPZQGGQ8VEVHGD6EIJWX7DC.md 'Cat\.Commands\.CatCommandProcessor\.CatCommandProcessor\(System\.IServiceProvider, Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_decoratorFactory](CatCommandProcessor._decoratorFactory.md 'Cat\.Commands\.CatCommandProcessor\.\_decoratorFactory') | |
| [\_serviceProvider](CatCommandProcessor._serviceProvider.md 'Cat\.Commands\.CatCommandProcessor\.\_serviceProvider') | |

| Methods | |
| :--- | :--- |
| [InvokeHandler\(MethodInfo, object, object, CancellationToken\)](CatCommandProcessor.InvokeHandler.BZRUWKGR5XGF9THSZES441X68.md 'Cat\.Commands\.CatCommandProcessor\.InvokeHandler\(System\.Reflection\.MethodInfo, object, object, System\.Threading\.CancellationToken\)') | Calls the handler\. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\. |
| [ProcessAsync\(ICatCommand, CancellationToken\)](CatCommandProcessor.ProcessAsync.I25DKPK8QD9F4OW1YGDUV0HM.md 'Cat\.Commands\.CatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command\. |

| Explicit Interface Implementations | |
| :--- | :--- |
| [Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(ICatCommand\)](CatCommandProcessor.Cat.Commands.Abstractions.ICatCommandProcessor.Process.7XX41PCOJIPB2H5F7CISV1BMC.md 'Cat\.Commands\.CatCommandProcessor\.Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.VVA0QGJV7BSKJ1729JAXLLQT8.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand,System\.Threading\.CancellationToken\)') when you can\. |
