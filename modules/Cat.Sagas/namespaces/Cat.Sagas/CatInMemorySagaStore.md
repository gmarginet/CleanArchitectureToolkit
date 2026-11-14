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

## CatInMemorySagaStore Class

An [ICatSagaStore](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore') that keeps the instances in memory\. Use it for tests and for trying a saga\.
The instances are gone when the process stops, so it is no store for a real service\. Register it as a singleton\.

```csharp
public sealed class CatInMemorySagaStore : Cat.Sagas.Abstractions.ICatSagaStore
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatInMemorySagaStore

Implements [ICatSagaStore](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore')

| Fields | |
| :--- | :--- |
| [\_instances](CatInMemorySagaStore._instances.md 'Cat\.Sagas\.CatInMemorySagaStore\.\_instances') | |

| Methods | |
| :--- | :--- |
| [AddAsync\(CatSagaInstance, CancellationToken\)](CatInMemorySagaStore.AddAsync.R6IX6ZUKO6D5JEBPBOJQCPGTE.md 'Cat\.Sagas\.CatInMemorySagaStore\.AddAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)') | Saves a new instance with [Version](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') 1\. |
| [Copy\(CatSagaInstance\)](CatInMemorySagaStore.Copy.73KAGJLIVHS2TPN25796MAPK9.md 'Cat\.Sagas\.CatInMemorySagaStore\.Copy\(Cat\.Sagas\.Abstractions\.CatSagaInstance\)') | |
| [FindAsync\(Guid, CancellationToken\)](CatInMemorySagaStore.FindAsync.70I2TXSBRYT73J2R5VKBATBP.md 'Cat\.Sagas\.CatInMemorySagaStore\.FindAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Finds an instance\. |
| [UpdateAsync\(CatSagaInstance, CancellationToken\)](CatInMemorySagaStore.UpdateAsync.27K3DPON6MGXZKMC4PHDA9FG4.md 'Cat\.Sagas\.CatInMemorySagaStore\.UpdateAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)') | Saves the changes of an instance and raises [Version](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') by one\. |
