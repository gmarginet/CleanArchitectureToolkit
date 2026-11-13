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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization Namespace](Cat.EventProcessor.Authorization.md 'Cat\.EventProcessor\.Authorization') >> [CatMessageTokenValidator Class](CatMessageTokenValidator.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator')

## CatMessageTokenValidator\.IsAlive\(Nullable\<DateTime\>, Nullable\<DateTime\>, DateTime, TimeSpan\) Method

```csharp
private static bool IsAlive(System.Nullable<System.DateTime> notBefore, System.Nullable<System.DateTime> expires, System.DateTime arrival, System.TimeSpan skew);
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.IsAlive(System.Nullable_System.DateTime_,System.Nullable_System.DateTime_,System.DateTime,System.TimeSpan).notBefore'></a>

`notBefore` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.IsAlive(System.Nullable_System.DateTime_,System.Nullable_System.DateTime_,System.DateTime,System.TimeSpan).expires'></a>

`expires` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.IsAlive(System.Nullable_System.DateTime_,System.Nullable_System.DateTime_,System.DateTime,System.TimeSpan).arrival'></a>

`arrival` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.IsAlive(System.Nullable_System.DateTime_,System.Nullable_System.DateTime_,System.DateTime,System.TimeSpan).skew'></a>

`skew` [System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')