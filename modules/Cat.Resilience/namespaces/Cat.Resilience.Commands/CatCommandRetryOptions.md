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
  
##### >> [Cat\.Resilience\.Commands Assembly](index.md 'index') >> [Cat\.Resilience\.Commands Namespace](Cat.Resilience.Commands.md 'Cat\.Resilience\.Commands')

## CatCommandRetryOptions Class

Lists the command types that are retried\. Nothing is retried by default\.

```csharp
public sealed class CatCommandRetryOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCommandRetryOptions

| Fields | |
| :--- | :--- |
| [\_rules](CatCommandRetryOptions._rules.md 'Cat\.Resilience\.Commands\.CatCommandRetryOptions\.\_rules') | |

| Properties | |
| :--- | :--- |
| [HasRules](CatCommandRetryOptions.HasRules.md 'Cat\.Resilience\.Commands\.CatCommandRetryOptions\.HasRules') | |

| Methods | |
| :--- | :--- |
| [IsCommand\(Type\)](CatCommandRetryOptions.IsCommand.Y53UALRTGCH6XFUZ5B1171XR3.md 'Cat\.Resilience\.Commands\.CatCommandRetryOptions\.IsCommand\(System\.Type\)') | |
| [Retry&lt;TCommand&gt;\(string, Action&lt;CatRetryRule&gt;\)](CatCommandRetryOptions.Retry.U3O97J2JCUQ2AX73VGDKOA6J9.md 'Cat\.Resilience\.Commands\.CatCommandRetryOptions\.Retry\<TCommand\>\(string, System\.Action\<Cat\.Resilience\.Commands\.CatRetryRule\>\)') | Retries a command type through a resilience profile\. Every other command is called once\. |
| [TryGetRule\(Type, CatRetryRule\)](CatCommandRetryOptions.TryGetRule.CFP9U7YLS4XEOCUX2JZB153C1.md 'Cat\.Resilience\.Commands\.CatCommandRetryOptions\.TryGetRule\(System\.Type, Cat\.Resilience\.Commands\.CatRetryRule\)') | |
