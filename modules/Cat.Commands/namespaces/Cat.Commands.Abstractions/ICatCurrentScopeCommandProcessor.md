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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands\.Abstractions Assembly](index.md 'index') >> [Cat\.Commands\.Abstractions Namespace](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions')

## ICatCurrentScopeCommandProcessor Interface

Runs a command in the scope of the caller, instead of in a scope of its own\.
The handler and everything it uses, such as a `DbContext`, are the same instances the caller sees in its scope\.
Use it when a command must commit together with work the caller prepared, like a handler of a received message that has an inbox row\.
[ICatCommandProcessor](ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor') keeps opening a scope per command\.

```csharp
public interface ICatCurrentScopeCommandProcessor
```

| Methods | |
| :--- | :--- |
| [ProcessInCurrentScopeAsync\(ICatCommand, CancellationToken\)](ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command in the scope of the caller\. |
| [ProcessInCurrentScopeAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result, in the scope of the caller\. |
