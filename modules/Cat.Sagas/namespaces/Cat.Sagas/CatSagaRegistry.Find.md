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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [CatSagaRegistry Class](CatSagaRegistry.md 'Cat\.Sagas\.CatSagaRegistry')

## CatSagaRegistry\.Find Method

| Overloads | |
| :--- | :--- |
| [Find\(string\)](CatSagaRegistry.Find.md#Cat.Sagas.CatSagaRegistry.Find(string) 'Cat\.Sagas\.CatSagaRegistry\.Find\(string\)') | |
| [Find\(Type\)](CatSagaRegistry.Find.md#Cat.Sagas.CatSagaRegistry.Find(System.Type) 'Cat\.Sagas\.CatSagaRegistry\.Find\(System\.Type\)') | |

<a name='Cat.Sagas.CatSagaRegistry.Find(string)'></a>

## CatSagaRegistry\.Find\(string\) Method

```csharp
public Cat.Sagas.ICatSagaDefinition? Find(string name);
```
#### Parameters

<a name='Cat.Sagas.CatSagaRegistry.Find(string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

#### Returns
[ICatSagaDefinition](ICatSagaDefinition.md 'Cat\.Sagas\.ICatSagaDefinition')

<a name='Cat.Sagas.CatSagaRegistry.Find(System.Type)'></a>

## CatSagaRegistry\.Find\(Type\) Method

```csharp
public Cat.Sagas.ICatSagaDefinition? Find(System.Type workflowType);
```
#### Parameters

<a name='Cat.Sagas.CatSagaRegistry.Find(System.Type).workflowType'></a>

`workflowType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

#### Returns
[ICatSagaDefinition](ICatSagaDefinition.md 'Cat\.Sagas\.ICatSagaDefinition')