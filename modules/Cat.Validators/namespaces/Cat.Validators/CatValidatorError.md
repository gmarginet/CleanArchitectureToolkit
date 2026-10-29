<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorError Class

Default [ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')\.

```csharp
public class CatValidatorError : Cat.Validators.Abstractions.ICatValidatorError
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorError

Implements [ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')

| Constructors | |
| :--- | :--- |
| [CatValidatorError\(string, string, string, IList&lt;object&gt;\)](CatValidatorError..ctor.7N10EQJ6DBT05VTNX9CI66RQ2.md 'Cat\.Validators\.CatValidatorError\.CatValidatorError\(string, string, string, System\.Collections\.Generic\.IList\<object\>\)') | Creates the error\. |

| Properties | |
| :--- | :--- |
| [Arguments](CatValidatorError.Arguments.md 'Cat\.Validators\.CatValidatorError\.Arguments') | The values for the message placeholders, in order\. |
| [Code](CatValidatorError.Code.md 'Cat\.Validators\.CatValidatorError\.Code') | The stable code of this kind of failure, like `CAT-VAL-1001`\. |
| [FieldName](CatValidatorError.FieldName.md 'Cat\.Validators\.CatValidatorError\.FieldName') | The name of the field that failed\. Nested validation prefixes it, like `Todo.Title` or `Items[0].Title`\. |
| [Message](CatValidatorError.Message.md 'Cat\.Validators\.CatValidatorError\.Message') | The message template\. Its placeholders match [Arguments](..\Cat.Validators.Abstractions\ICatValidatorError.Arguments.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.Arguments')\. |

| Methods | |
| :--- | :--- |
| [Create\(string, string, string, object\[\]\)](CatValidatorError.Create.X45VDD5EY5ZFWIORV3ENFGRL9.md 'Cat\.Validators\.CatValidatorError\.Create\(string, string, string, object\[\]\)') | Creates an error\. |
