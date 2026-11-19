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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands Assembly](index.md 'index') >> [Cat\.Commands Namespace](Cat.Commands.md 'Cat\.Commands')

## CatCommandProcessor Class

Default [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor') and [ICatCurrentScopeCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCurrentScopeCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor')\.
Opens a new scope per command, gets the decorated handler from it and invokes the handler\.
The current scope variant skips the new scope and uses the scope of the caller\.

```csharp
internal class CatCommandProcessor : Cat.Commands.Abstractions.ICatCommandProcessor, Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCommandProcessor

Implements [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor'), [ICatCurrentScopeCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCurrentScopeCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor')

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
| [ProcessAsync\(ICatCommand, CancellationToken\)](CatCommandProcessor.ProcessAsync.md#Cat.Commands.CatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command\. |
| [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](CatCommandProcessor.ProcessAsync.md#Cat.Commands.CatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result\. |
| [ProcessInCurrentScopeAsync\(ICatCommand, CancellationToken\)](CatCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.CatCommandProcessor.ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.ProcessInCurrentScopeAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command in the scope of the caller\. |
| [ProcessInCurrentScopeAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](CatCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.CatCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.ProcessInCurrentScopeAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result, in the scope of the caller\. |
| [RunHandlerAsync\(IServiceProvider, ICatCommand, CancellationToken\)](CatCommandProcessor.RunHandlerAsync.md#Cat.Commands.CatCommandProcessor.RunHandlerAsync(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.RunHandlerAsync\(System\.IServiceProvider, Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | |
| [RunHandlerAsync&lt;TResult&gt;\(IServiceProvider, ICatCommand&lt;TResult&gt;, CancellationToken\)](CatCommandProcessor.RunHandlerAsync.md#Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.RunHandlerAsync\<TResult\>\(System\.IServiceProvider, Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | |

| Explicit Interface Implementations | |
| :--- | :--- |
| [Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(ICatCommand\)](CatCommandProcessor.Cat.Commands.Abstractions.ICatCommandProcessor.Process.7XX41PCOJIPB2H5F7CISV1BMC.md 'Cat\.Commands\.CatCommandProcessor\.Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand,System\.Threading\.CancellationToken\)') when you can\. |
| [Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;\)](CatCommandProcessor.Cat.Commands.Abstractions.ICatCommandProcessor.Process.KOEHSSPY3E1XSB9REZR12QLND.md 'Cat\.Commands\.CatCommandProcessor\.Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)') | Runs a command that returns a result and blocks until it finishes\. Prefer [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\`\`1\(Cat\.Commands\.Abstractions\.ICatCommand\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
