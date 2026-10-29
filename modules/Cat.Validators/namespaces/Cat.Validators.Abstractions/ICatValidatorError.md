<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorError Interface

One validation failure\.

```csharp
public interface ICatValidatorError
```

| Properties | |
| :--- | :--- |
| [Arguments](ICatValidatorError.Arguments.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.Arguments') | The values for the message placeholders, in order\. |
| [Code](ICatValidatorError.Code.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.Code') | The stable code of this kind of failure, like `CAT-VAL-1001`\. |
| [FieldName](ICatValidatorError.FieldName.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.FieldName') | The name of the field that failed\. Nested validation prefixes it, like `Todo.Title` or `Items[0].Title`\. |
| [Message](ICatValidatorError.Message.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.Message') | The message template\. Its placeholders match [Arguments](ICatValidatorError.Arguments.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.Arguments')\. |
