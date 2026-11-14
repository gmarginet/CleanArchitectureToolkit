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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas')

## SystemTextJsonSagaSerializer Class

[ICatSagaSerializer](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaSerializer.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer') on System\.Text\.Json with the web defaults\.
            It also gives the loop state of a foreach in a checkpoint its type back, because the checkpoint holds it as an object\.

```csharp
public sealed class SystemTextJsonSagaSerializer : Cat.Sagas.Abstractions.ICatSagaSerializer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SystemTextJsonSagaSerializer

Implements [ICatSagaSerializer](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaSerializer.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer')

| Fields | |
| :--- | :--- |
| [Options](SystemTextJsonSagaSerializer.Options.md 'Cat\.Sagas\.SystemTextJsonSagaSerializer\.Options') | |

| Methods | |
| :--- | :--- |
| [Deserialize\(string, Type\)](SystemTextJsonSagaSerializer.Deserialize.JL0AVPP1X2CMB1Z40VM2WFZGC.md 'Cat\.Sagas\.SystemTextJsonSagaSerializer\.Deserialize\(string, System\.Type\)') | Turns text back into a value\. |
| [RestoreLoopState\(CatCheckpointFrame\)](SystemTextJsonSagaSerializer.RestoreLoopState.5LCJ293DSFC3FSX5TEHZ3LLG7.md 'Cat\.Sagas\.SystemTextJsonSagaSerializer\.RestoreLoopState\(Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\)') | |
| [Serialize\(object, Type\)](SystemTextJsonSagaSerializer.Serialize.UPV45509LBMNZFU6KGU7VCX71.md 'Cat\.Sagas\.SystemTextJsonSagaSerializer\.Serialize\(object, System\.Type\)') | Turns a value into text\. |
