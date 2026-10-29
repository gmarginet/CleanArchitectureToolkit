<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorModelRuleBuilder&lt;TModel&gt;](CatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>')

## CatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\) Method

Adds a rule to the validator\.

```csharp
public void AddRule<TRule>(TRule newRule)
    where TRule : class, Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule'></a>

`TRule`

The type of the rule\.
#### Parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).newRule'></a>

`newRule` [TRule](CatValidatorModelRuleBuilder_TModel_.AddRule.PLYT02AZTLYKVXGLD1RU5XKVD.md#Cat.Validators.CatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)\.TRule')

The rule to add\. It must derive from [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')\.

Implements [AddRule&lt;TRule&gt;\(TRule\)](..\Cat.Validators.Abstractions\ICatValidatorModelRuleBuilder_TModel_.AddRule.NTZUA8M66NHJI05PHAP0R47G7.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1\.AddRule\`\`1\(\`\`0\)')

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The rule doesn't derive from [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')\.