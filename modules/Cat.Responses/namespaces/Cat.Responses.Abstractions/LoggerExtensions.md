<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions\.Extensions](Cat.Responses.Abstractions.Extensions.md 'Cat\.Responses\.Abstractions\.Extensions')

## LoggerExtensions Class

Extension methods for logging [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') errors\.

```csharp
public static class LoggerExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LoggerExtensions

| Methods | |
| :--- | :--- |
| [LogCatResponseErrors\(this ILogger, ICatResponse, string, object\[\]\)](LoggerExtensions.LogCatResponseErrors.A3RSKW2WBV6A3X4OGKEIX9H1D.md 'Cat\.Responses\.Abstractions\.Extensions\.LoggerExtensions\.LogCatResponseErrors\(this Microsoft\.Extensions\.Logging\.ILogger, Cat\.Responses\.Abstractions\.ICatResponse, string, object\[\]\)') | Logs a message, followed by one log entry per error in the response's [ErrorList](ICatResponse.ErrorList.md 'Cat\.Responses\.Abstractions\.ICatResponse\.ErrorList')\. |
