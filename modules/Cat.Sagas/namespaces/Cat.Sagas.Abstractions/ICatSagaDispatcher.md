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
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index') >> [Cat\.Sagas\.Abstractions Namespace](Cat.Sagas.Abstractions.md 'Cat\.Sagas\.Abstractions')

## ICatSagaDispatcher Interface

Gives an answer to a waiting saga\. It finds the instance, resumes the workflow at the wait step and saves the result\.
The handler that `AddCatSagaAnswer` registers calls it for you\.

```csharp
public interface ICatSagaDispatcher
```

| Methods | |
| :--- | :--- |
| [ResumeAsync\(Guid, object, CancellationToken\)](ICatSagaDispatcher.ResumeAsync.ITMGKI4U7JF3ANEOQ22KR1WD2.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher\.ResumeAsync\(System\.Guid, object, System\.Threading\.CancellationToken\)') | Resumes the instance with the answer\. |
| [TimeoutAsync\(Guid, Guid, CancellationToken\)](ICatSagaDispatcher.TimeoutAsync.FW7ZC320WTINFPP98AU9EN7A6.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher\.TimeoutAsync\(System\.Guid, System\.Guid, System\.Threading\.CancellationToken\)') | Times out one wait of the instance\. The workflow resumes at the wait step with `TimedOut` set and no answer\. The handler for `CatSagaTimeout` calls it for you\. |
