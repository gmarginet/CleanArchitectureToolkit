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
  
##### >> [Cat\.Inbox\.AspNetCore Assembly](index.md 'index') >> [Cat\.Inbox\.AspNetCore\.Extensions Namespace](Cat.Inbox.AspNetCore.Extensions.md 'Cat\.Inbox\.AspNetCore\.Extensions') >> [EndpointConventionBuilderExtensions Class](EndpointConventionBuilderExtensions.md 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions')

## EndpointConventionBuilderExtensions\.WithCatInbox Method

| Overloads | |
| :--- | :--- |
| [WithCatInbox&lt;TBuilder,TArgument&gt;\(this TBuilder, Func&lt;TArgument,string&gt;, int\)](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int) 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder,TArgument\>\(this TBuilder, System\.Func\<TArgument,string\>, int\)') | Skips a call whose id was handled before\. The id comes from an argument the endpoint already bound, such as the body\. |
| [WithCatInbox&lt;TBuilder&gt;\(this TBuilder, string, int\)](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int) 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder\>\(this TBuilder, string, int\)') | Skips a call whose id was handled before\. The id is the value of a header, such as `webhook-id`\. |

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int)'></a>

## EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder,TArgument\>\(this TBuilder, Func\<TArgument,string\>, int\) Method

Skips a call whose id was handled before\. The id comes from an argument the endpoint already bound, such as the body\.

```csharp
public static TBuilder WithCatInbox<TBuilder,TArgument>(this TBuilder builder, System.Func<TArgument,string?> idSelector, int repeatStatusCode=200)
    where TBuilder : Microsoft.AspNetCore.Builder.IEndpointConventionBuilder;
```
#### Type parameters

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).TBuilder'></a>

`TBuilder`

The type of the endpoint builder\.

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).TArgument'></a>

`TArgument`

The type of the bound argument that holds the id\.
#### Parameters

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).builder'></a>

`builder` [TBuilder](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).TBuilder 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder,TArgument\>\(this TBuilder, System\.Func\<TArgument,string\>, int\)\.TBuilder')

The endpoint builder\.

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).idSelector'></a>

`idSelector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TArgument](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).TArgument 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder,TArgument\>\(this TBuilder, System\.Func\<TArgument,string\>, int\)\.TArgument')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Reads the id from the argument\.

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).repeatStatusCode'></a>

`repeatStatusCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The status that a repeated call gets\. The body is empty\.

#### Returns
[TBuilder](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder,TArgument_(thisTBuilder,System.Func_TArgument,string_,int).TBuilder 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder,TArgument\>\(this TBuilder, System\.Func\<TArgument,string\>, int\)\.TBuilder')  
The same builder, so calls can be chained\.

### Remarks
Use it for a provider that sends the id in the body\. The filter finds the argument by its type, so the endpoint
must have exactly one argument of that type\. See the overload with a header for the rest of the rules\.

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int)'></a>

## EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder\>\(this TBuilder, string, int\) Method

Skips a call whose id was handled before\. The id is the value of a header, such as `webhook-id`\.

```csharp
public static TBuilder WithCatInbox<TBuilder>(this TBuilder builder, string header, int repeatStatusCode=200)
    where TBuilder : Microsoft.AspNetCore.Builder.IEndpointConventionBuilder;
```
#### Type parameters

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int).TBuilder'></a>

`TBuilder`

The type of the endpoint builder\.
#### Parameters

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int).builder'></a>

`builder` [TBuilder](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int).TBuilder 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder\>\(this TBuilder, string, int\)\.TBuilder')

The endpoint builder\.

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int).header'></a>

`header` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the header with the id of the call\.

<a name='Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int).repeatStatusCode'></a>

`repeatStatusCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The status that a repeated call gets\. The body is empty\.

#### Returns
[TBuilder](EndpointConventionBuilderExtensions.WithCatInbox.md#Cat.Inbox.AspNetCore.Extensions.EndpointConventionBuilderExtensions.WithCatInbox_TBuilder_(thisTBuilder,string,int).TBuilder 'Cat\.Inbox\.AspNetCore\.Extensions\.EndpointConventionBuilderExtensions\.WithCatInbox\<TBuilder\>\(this TBuilder, string, int\)\.TBuilder')  
The same builder, so calls can be chained\.

### Remarks
The filter adds a row to the `DbContext` of the request scope, and the endpoint saves it with its own `SaveChanges`\.
A call that fails saves nothing\. A call without the header is handled without the inbox, and the filter logs a warning\.
Check the signature of a webhook before this filter, with the SDK of the provider\.