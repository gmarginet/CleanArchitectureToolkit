<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions\.Extensions](Cat.Responses.Abstractions.Extensions.md 'Cat\.Responses\.Abstractions\.Extensions') > [LoggerExtensions](LoggerExtensions.md 'Cat\.Responses\.Abstractions\.Extensions\.LoggerExtensions')

## LoggerExtensions\.LogCatResponseErrors\(this ILogger, ICatResponse, string, object\[\]\) Method

Logs a message, followed by one log entry per error in the response's [ErrorList](ICatResponse.ErrorList.md 'Cat\.Responses\.Abstractions\.ICatResponse\.ErrorList')\.

```csharp
public static void LogCatResponseErrors(this Microsoft.Extensions.Logging.ILogger logger, Cat.Responses.Abstractions.ICatResponse catResponse, string message, params object[] args);
```
#### Parameters

<a name='Cat.Responses.Abstractions.Extensions.LoggerExtensions.LogCatResponseErrors(thisMicrosoft.Extensions.Logging.ILogger,Cat.Responses.Abstractions.ICatResponse,string,object[]).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')

The logger to write to\.

<a name='Cat.Responses.Abstractions.Extensions.LoggerExtensions.LogCatResponseErrors(thisMicrosoft.Extensions.Logging.ILogger,Cat.Responses.Abstractions.ICatResponse,string,object[]).catResponse'></a>

`catResponse` [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response whose errors should be logged\.

<a name='Cat.Responses.Abstractions.Extensions.LoggerExtensions.LogCatResponseErrors(thisMicrosoft.Extensions.Logging.ILogger,Cat.Responses.Abstractions.ICatResponse,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message to log before the individual errors\.

<a name='Cat.Responses.Abstractions.Extensions.LoggerExtensions.LogCatResponseErrors(thisMicrosoft.Extensions.Logging.ILogger,Cat.Responses.Abstractions.ICatResponse,string,object[]).args'></a>

`args` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into [message](LoggerExtensions.LogCatResponseErrors.A3RSKW2WBV6A3X4OGKEIX9H1D.md#Cat.Responses.Abstractions.Extensions.LoggerExtensions.LogCatResponseErrors(thisMicrosoft.Extensions.Logging.ILogger,Cat.Responses.Abstractions.ICatResponse,string,object[]).message 'Cat\.Responses\.Abstractions\.Extensions\.LoggerExtensions\.LogCatResponseErrors\(this Microsoft\.Extensions\.Logging\.ILogger, Cat\.Responses\.Abstractions\.ICatResponse, string, object\[\]\)\.message')'s placeholders\.