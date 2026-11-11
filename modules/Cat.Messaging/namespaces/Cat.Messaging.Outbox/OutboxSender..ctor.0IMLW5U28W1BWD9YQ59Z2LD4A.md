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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MESSAGING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Messaging\.Outbox Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox Namespace](Cat.Messaging.Outbox.md 'Cat\.Messaging\.Outbox') >> [OutboxSender Class](OutboxSender.md 'Cat\.Messaging\.Outbox\.OutboxSender')

## OutboxSender\(IServiceScopeFactory, IOptions\<CatOutboxOptions\>, ILogger\<OutboxSender\>\) Constructor

Creates the sender\.

```csharp
public OutboxSender(Microsoft.Extensions.DependencyInjection.IServiceScopeFactory scopeFactory, Microsoft.Extensions.Options.IOptions<Cat.Messaging.Outbox.CatOutboxOptions> options, Microsoft.Extensions.Logging.ILogger<Cat.Messaging.Outbox.OutboxSender> logger);
```
#### Parameters

<a name='Cat.Messaging.Outbox.OutboxSender.OutboxSender(Microsoft.Extensions.DependencyInjection.IServiceScopeFactory,Microsoft.Extensions.Options.IOptions_Cat.Messaging.Outbox.CatOutboxOptions_,Microsoft.Extensions.Logging.ILogger_Cat.Messaging.Outbox.OutboxSender_).scopeFactory'></a>

`scopeFactory` [Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicescopefactory 'Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory')

Opens a scope for each round, because the store is scoped\.

<a name='Cat.Messaging.Outbox.OutboxSender.OutboxSender(Microsoft.Extensions.DependencyInjection.IServiceScopeFactory,Microsoft.Extensions.Options.IOptions_Cat.Messaging.Outbox.CatOutboxOptions_,Microsoft.Extensions.Logging.ILogger_Cat.Messaging.Outbox.OutboxSender_).options'></a>

`options` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[CatOutboxOptions](CatOutboxOptions.md 'Cat\.Messaging\.Outbox\.CatOutboxOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')

The settings of the outbox\.

<a name='Cat.Messaging.Outbox.OutboxSender.OutboxSender(Microsoft.Extensions.DependencyInjection.IServiceScopeFactory,Microsoft.Extensions.Options.IOptions_Cat.Messaging.Outbox.CatOutboxOptions_,Microsoft.Extensions.Logging.ILogger_Cat.Messaging.Outbox.OutboxSender_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[OutboxSender](OutboxSender.md 'Cat\.Messaging\.Outbox\.OutboxSender')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger\.