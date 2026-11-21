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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience\.Abstractions Assembly](index.md 'index') >> [Cat\.Resilience\.Abstractions Namespace](Cat.Resilience.Abstractions.md 'Cat\.Resilience\.Abstractions')

## CatRetryOptions Class

Settings of the retry of a profile\.

```csharp
public sealed class CatRetryOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatRetryOptions

| Properties | |
| :--- | :--- |
| [BackoffType](CatRetryOptions.BackoffType.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.BackoffType') | Gets or sets how the delay grows\. The default is [Exponential](CatBackoffType.md#Cat.Resilience.Abstractions.CatBackoffType.Exponential 'Cat\.Resilience\.Abstractions\.CatBackoffType\.Exponential')\. |
| [Delay](CatRetryOptions.Delay.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.Delay') | Gets or sets the delay before the first retry\. The default is 2 seconds\. |
| [IdempotencyHeaderName](CatRetryOptions.IdempotencyHeaderName.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.IdempotencyHeaderName') | Gets or sets the name of the idempotency key header\. The default is `Idempotency-Key`\. |
| [MaxRetryAttempts](CatRetryOptions.MaxRetryAttempts.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.MaxRetryAttempts') | Gets or sets how many times a failed call is tried again\. The default is 3\. Zero switches the retry off\. |
| [RequireIdempotencyKeyForUnsafeMethods](CatRetryOptions.RequireIdempotencyKeyForUnsafeMethods.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.RequireIdempotencyKeyForUnsafeMethods') | Gets or sets whether a `POST`, `PUT`, `PATCH` or `DELETE` is retried only when the request carries the idempotency key header\. The default is false\. It has an effect on an HTTP call only\. |
| [UseJitter](CatRetryOptions.UseJitter.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.UseJitter') | Gets or sets whether a random part is added to the delay, so many callers do not retry at the same moment\. The default is true\. |
| [UseRetryAfterHeader](CatRetryOptions.UseRetryAfterHeader.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions\.UseRetryAfterHeader') | Gets or sets whether the `Retry-After` header of a response sets the delay\. The default is false\. It has an effect on an HTTP call only\. |
