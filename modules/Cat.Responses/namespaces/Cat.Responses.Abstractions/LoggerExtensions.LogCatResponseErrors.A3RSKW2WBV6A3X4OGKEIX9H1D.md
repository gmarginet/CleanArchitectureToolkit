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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses\.Abstractions Assembly](index.md 'index') >> [Cat\.Responses\.Abstractions\.Extensions Namespace](Cat.Responses.Abstractions.Extensions.md 'Cat\.Responses\.Abstractions\.Extensions') >> [LoggerExtensions Class](LoggerExtensions.md 'Cat\.Responses\.Abstractions\.Extensions\.LoggerExtensions')

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