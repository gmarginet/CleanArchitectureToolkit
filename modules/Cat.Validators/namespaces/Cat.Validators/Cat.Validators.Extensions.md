<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index')

## Cat\.Validators\.Extensions Namespace

| Classes | |
| :--- | :--- |
| [CatValidatorErrorExtensions](CatValidatorErrorExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorErrorExtensions') | Conversion helpers for validator errors\. |
| [CatValidatorModelRuleBuilderExtensions](CatValidatorModelRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions') | Rules that look at the whole model\. Use them inside [AddRules\(Action&lt;ICatValidatorModelRuleBuilder&lt;TModel&gt;&gt;\)](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.AddRules.7LVEP6J7EA1YDLNO2MIA8L6N1.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddRules\(System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\{\`0\}\}\)')\. |
| [CatValidatorPropertyRuleBuilderExtensions](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions') | The built\-in property rules\. Use them inside [AddPropertyRules&lt;TProperty&gt;\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, Action&lt;ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;&gt;\)](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.AddPropertyRules.4SGJLPHSDC95BLHV1D531FAK5.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddPropertyRules\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\{\`0,\`\`0\}\}\)')\. Each rule returns an options builder, so you can chain `When`, `WithFieldName`, `WithMessage` and `WithCode`\. |
| [CatValidatorPropertyRuleOptionsBuilderExtensions](CatValidatorPropertyRuleOptionsBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions') | Options you can chain after a property rule: conditions, a field name, a message and a code\. Each option applies only to the rule right before it\. |
| [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Validators\.Extensions\.ServiceCollectionExtensions') | Registration helpers for the validators module\. |
