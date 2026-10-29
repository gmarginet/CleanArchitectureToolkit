<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions')

## ICatError Interface

Describes one error that caused a response to fail\.

```csharp
public interface ICatError
```

| Properties | |
| :--- | :--- |
| [Arguments](ICatError.Arguments.md 'Cat\.Responses\.Abstractions\.ICatError\.Arguments') | The values to substitute into the message's placeholders, in order\. |
| [Code](ICatError.Code.md 'Cat\.Responses\.Abstractions\.ICatError\.Code') | A stable code identifying the kind of error, independent of its message text\. |
| [Message](ICatError.Message.md 'Cat\.Responses\.Abstractions\.ICatError\.Message') | A human\-readable message describing the error\. Can contain placeholders filled in by [Arguments](ICatError.Arguments.md 'Cat\.Responses\.Abstractions\.ICatError\.Arguments')\. |
