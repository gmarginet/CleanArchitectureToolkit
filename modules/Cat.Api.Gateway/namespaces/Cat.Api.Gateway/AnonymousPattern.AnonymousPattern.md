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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.GATEWAY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration') >> [AnonymousPattern Class](AnonymousPattern.md 'Cat\.Api\.Gateway\.Configuration\.AnonymousPattern')

## AnonymousPattern Constructors

| Overloads | |
| :--- | :--- |
| [AnonymousPattern\(\)](AnonymousPattern.AnonymousPattern.md#Cat.Api.Gateway.Configuration.AnonymousPattern.AnonymousPattern() 'Cat\.Api\.Gateway\.Configuration\.AnonymousPattern\.AnonymousPattern\(\)') | |
| [AnonymousPattern\(string\[\], string\[\]\)](AnonymousPattern.AnonymousPattern.md#Cat.Api.Gateway.Configuration.AnonymousPattern.AnonymousPattern(string[],string[]) 'Cat\.Api\.Gateway\.Configuration\.AnonymousPattern\.AnonymousPattern\(string\[\], string\[\]\)') | One entry of [Anonymous](CatGatewayServiceOptions.Anonymous.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Anonymous'), parsed and checked\. |

<a name='Cat.Api.Gateway.Configuration.AnonymousPattern.AnonymousPattern()'></a>

## AnonymousPattern\(\) Constructor

```csharp
static AnonymousPattern();
```

<a name='Cat.Api.Gateway.Configuration.AnonymousPattern.AnonymousPattern(string[],string[])'></a>

## AnonymousPattern\(string\[\], string\[\]\) Constructor

One entry of [Anonymous](CatGatewayServiceOptions.Anonymous.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Anonymous'), parsed and checked\.

```csharp
public AnonymousPattern(string[]? Methods, string[] Segments);
```
#### Parameters

<a name='Cat.Api.Gateway.Configuration.AnonymousPattern.AnonymousPattern(string[],string[]).Methods'></a>

`Methods` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='Cat.Api.Gateway.Configuration.AnonymousPattern.AnonymousPattern(string[],string[]).Segments'></a>

`Segments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')