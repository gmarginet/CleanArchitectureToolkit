<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests](index.md 'index') > [Cat\.ServiceRequests](Cat.ServiceRequests.md 'Cat\.ServiceRequests')

## CatServiceRequestProcessor Class

Default [ICatServiceRequestProcessor](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor')\.
Opens a new scope per request, gets the decorated handler from it and invokes the handler\.

```csharp
internal class CatServiceRequestProcessor : Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatServiceRequestProcessor

Implements [ICatServiceRequestProcessor](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestProcessor\(IServiceProvider, ICatDecoratorFactory\)](CatServiceRequestProcessor..ctor.0OC9KO82KE4TQ804ZYRHMOD08.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.CatServiceRequestProcessor\(System\.IServiceProvider, Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_decoratorFactory](CatServiceRequestProcessor._decoratorFactory.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.\_decoratorFactory') | |
| [\_serviceProvider](CatServiceRequestProcessor._serviceProvider.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.\_serviceProvider') | |

| Methods | |
| :--- | :--- |
| [InvokeHandler\(MethodInfo, object, object, CancellationToken\)](CatServiceRequestProcessor.InvokeHandler.ZNKTZWMPLYP7H2EPPK7DJU6LB.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.InvokeHandler\(System\.Reflection\.MethodInfo, object, object, System\.Threading\.CancellationToken\)') | Calls the handler\. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\. |
| [Process\(ICatServiceRequest\)](CatServiceRequestProcessor.Process.md#Cat.ServiceRequests.CatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest,System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](CatServiceRequestProcessor.Process.md#Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatServiceRequest, CancellationToken\)](CatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.CatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') | Runs a service request that returns no payload\. |
| [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](CatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.CatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') | Runs a service request that returns a payload\. |
