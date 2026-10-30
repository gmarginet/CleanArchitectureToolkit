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
  
##### >> [Cat\.Responses\.Abstractions Assembly](index.md 'index') >> [Cat\.Responses\.Abstractions\.Extensions Namespace](Cat.Responses.Abstractions.Extensions.md 'Cat\.Responses\.Abstractions\.Extensions')

## LoggerExtensions Class

Extension methods for logging [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') errors\.

```csharp
public static class LoggerExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LoggerExtensions

| Methods | |
| :--- | :--- |
| [LogCatResponseErrors\(this ILogger, ICatResponse, string, object\[\]\)](LoggerExtensions.LogCatResponseErrors.A3RSKW2WBV6A3X4OGKEIX9H1D.md 'Cat\.Responses\.Abstractions\.Extensions\.LoggerExtensions\.LogCatResponseErrors\(this Microsoft\.Extensions\.Logging\.ILogger, Cat\.Responses\.Abstractions\.ICatResponse, string, object\[\]\)') | Logs a message, followed by one log entry per error in the response's [ErrorList](ICatResponse.ErrorList.md 'Cat\.Responses\.Abstractions\.ICatResponse\.ErrorList')\. |
