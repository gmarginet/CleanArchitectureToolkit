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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.INBOX](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Inbox\.AspNetCore Assembly](index.md 'index') >> [Cat\.Inbox\.AspNetCore Namespace](Cat.Inbox.AspNetCore.md 'Cat\.Inbox\.AspNetCore') >> [CatInboxEndpointFilter Class](CatInboxEndpointFilter.md 'Cat\.Inbox\.AspNetCore\.CatInboxEndpointFilter')

## CatInboxEndpointFilter\.InvokeAsync\(EndpointFilterInvocationContext, EndpointFilterDelegate, Func\<EndpointFilterInvocationContext,string\>, string, int\) Method

Skips the call when its id was handled before\. Otherwise it adds a row for the id to the context of the request scope
and runs the endpoint\. The endpoint saves the row with its own `SaveChanges`\.

```csharp
internal static System.Threading.Tasks.ValueTask<object?> InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext context, Microsoft.AspNetCore.Http.EndpointFilterDelegate next, System.Func<Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,string?> readId, string idSource, int repeatStatusCode);
```
#### Parameters

<a name='Cat.Inbox.AspNetCore.CatInboxEndpointFilter.InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,Microsoft.AspNetCore.Http.EndpointFilterDelegate,System.Func_Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,string_,string,int).context'></a>

`context` [Microsoft\.AspNetCore\.Http\.EndpointFilterInvocationContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.endpointfilterinvocationcontext 'Microsoft\.AspNetCore\.Http\.EndpointFilterInvocationContext')

<a name='Cat.Inbox.AspNetCore.CatInboxEndpointFilter.InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,Microsoft.AspNetCore.Http.EndpointFilterDelegate,System.Func_Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,string_,string,int).next'></a>

`next` [Microsoft\.AspNetCore\.Http\.EndpointFilterDelegate](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.endpointfilterdelegate 'Microsoft\.AspNetCore\.Http\.EndpointFilterDelegate')

<a name='Cat.Inbox.AspNetCore.CatInboxEndpointFilter.InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,Microsoft.AspNetCore.Http.EndpointFilterDelegate,System.Func_Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,string_,string,int).readId'></a>

`readId` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.EndpointFilterInvocationContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.endpointfilterinvocationcontext 'Microsoft\.AspNetCore\.Http\.EndpointFilterInvocationContext')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Inbox.AspNetCore.CatInboxEndpointFilter.InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,Microsoft.AspNetCore.Http.EndpointFilterDelegate,System.Func_Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,string_,string,int).idSource'></a>

`idSource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Inbox.AspNetCore.CatInboxEndpointFilter.InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,Microsoft.AspNetCore.Http.EndpointFilterDelegate,System.Func_Microsoft.AspNetCore.Http.EndpointFilterInvocationContext,string_,string,int).repeatStatusCode'></a>

`repeatStatusCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

#### Returns
[System\.Threading\.Tasks\.ValueTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')