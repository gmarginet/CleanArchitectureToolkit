<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorPropertyRuleBuilderExtensions](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.Must Method

| Overloads | |
| :--- | :--- |
| [Must&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TProperty,string,List&lt;ICatValidatorError&gt;&gt;\)](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Adds a rule that checks the property with your own code\. You build the errors yourself, so the other options don't apply\. |
| [Must&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TProperty,string,TModel,List&lt;ICatValidatorError&gt;&gt;\)](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Adds a rule that checks the property with your own code and can look at the whole model\. You build the errors yourself, so the other options don't apply\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TProperty,string,List\<ICatValidatorError\>\>\) Method

Adds a rule that checks the property with your own code\.
You build the errors yourself, so the other options don't apply\.

```csharp
public static void Must<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TProperty,string,System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> predicate)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TProperty](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

Gets the value and the field name\. Returns the failures, or an empty list\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TProperty,string,TModel,List\<ICatValidatorError\>\>\) Method

Adds a rule that checks the property with your own code and can look at the whole model\.
You build the errors yourself, so the other options don't apply\.

```csharp
public static void Must<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TProperty,string,TModel,System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> predicate)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TProperty](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TModel](CatValidatorPropertyRuleBuilderExtensions.Must.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Must_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Must\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')

Gets the value, the field name and the model\. Returns the failures, or an empty list\.