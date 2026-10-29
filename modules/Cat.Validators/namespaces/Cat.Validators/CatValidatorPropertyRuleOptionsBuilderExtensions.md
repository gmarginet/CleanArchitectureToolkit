<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions')

## CatValidatorPropertyRuleOptionsBuilderExtensions Class

Options you can chain after a property rule: conditions, a field name, a message and a code\.
Each option applies only to the rule right before it\.

```csharp
public static class CatValidatorPropertyRuleOptionsBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorPropertyRuleOptionsBuilderExtensions

| Methods | |
| :--- | :--- |
| [When&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, Expression&lt;Func&lt;TModel,bool&gt;&gt;\)](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)') | Runs the rule only when the condition returns `true`\. Add several conditions and all of them must be `true`\. |
| [WhenAsync&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, Expression&lt;Func&lt;TModel,CancellationToken,Task&lt;bool&gt;&gt;&gt;\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WhenAsync.GM5EL2IPZQZPFMIWZ8SJAKF34.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WhenAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<bool\>\>\>\)') | Runs the rule only when the async condition returns `true`\. Add several conditions and all of them must be `true`\. |
| [WithCode&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, string\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode.7Y5DVK7CTG2ZDYPAMFRVSBS8C.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)') | Replaces the code in the errors of the rule\. |
| [WithFieldName&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, string\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WithFieldName.I4JZVSI39JNZHWSH8NM9X1V76.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithFieldName\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)') | Replaces the field name in the errors of the rule\. |
| [WithMessage&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, string\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage.8EVOMAEFKOBSAYJYWNF7VAW01.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)') | Replaces the message in the errors of the rule\. The arguments of the rule still fill the placeholders, so you can reuse them\. |
