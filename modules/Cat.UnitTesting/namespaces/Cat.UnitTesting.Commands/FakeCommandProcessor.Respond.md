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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.Commands Assembly](index.md 'index') >> [Cat\.UnitTesting\.Commands Namespace](Cat.UnitTesting.Commands.md 'Cat\.UnitTesting\.Commands') >> [FakeCommandProcessor Class](FakeCommandProcessor.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor')

## FakeCommandProcessor\.Respond Method

| Overloads | |
| :--- | :--- |
| [Respond&lt;TCommand,TResult&gt;\(ICatResponse&lt;TResult&gt;\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\)') | Sets the response for a command with a result\. |
| [Respond&lt;TCommand,TResult&gt;\(Func&lt;TCommand,ICatResponse&lt;TResult&gt;&gt;\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\>\)') | Sets the response for a command with a result, built from the command\. |
| [Respond&lt;TCommand&gt;\(ICatResponse\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(Cat.Responses.Abstractions.ICatResponse) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand\>\(Cat\.Responses\.Abstractions\.ICatResponse\)') | Sets the response for a command without a result\. |
| [Respond&lt;TCommand&gt;\(Func&lt;TCommand,ICatResponse&gt;\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\>\)') | Sets the response for a command without a result, built from the command\. |

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_)'></a>

## FakeCommandProcessor\.Respond\<TCommand,TResult\>\(ICatResponse\<TResult\>\) Method

Sets the response for a command with a result\.

```csharp
public Cat.UnitTesting.Commands.FakeCommandProcessor Respond<TCommand,TResult>(Cat.Responses.Abstractions.ICatResponse<TResult> response)
    where TCommand : Cat.Commands.Abstractions.ICatCommand<TResult>;
```
#### Type parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_).TCommand'></a>

`TCommand`

The command type\.

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_).TResult'></a>

`TResult`

The type of the result\.
#### Parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_).response'></a>

`response` [Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_).TResult 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\)\.TResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

The response every command of this type gets\.

#### Returns
[FakeCommandProcessor](FakeCommandProcessor.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__)'></a>

## FakeCommandProcessor\.Respond\<TCommand,TResult\>\(Func\<TCommand,ICatResponse\<TResult\>\>\) Method

Sets the response for a command with a result, built from the command\.

```csharp
public Cat.UnitTesting.Commands.FakeCommandProcessor Respond<TCommand,TResult>(System.Func<TCommand,Cat.Responses.Abstractions.ICatResponse<TResult>> respond)
    where TCommand : Cat.Commands.Abstractions.ICatCommand<TResult>;
```
#### Type parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__).TCommand'></a>

`TCommand`

The command type\.

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__).TResult'></a>

`TResult`

The type of the result\.
#### Parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__).respond'></a>

`respond` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TCommand](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__).TCommand 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\>\)\.TCommand')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__).TResult 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\>\)\.TResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the response from the command\.

#### Returns
[FakeCommandProcessor](FakeCommandProcessor.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(Cat.Responses.Abstractions.ICatResponse)'></a>

## FakeCommandProcessor\.Respond\<TCommand\>\(ICatResponse\) Method

Sets the response for a command without a result\.

```csharp
public Cat.UnitTesting.Commands.FakeCommandProcessor Respond<TCommand>(Cat.Responses.Abstractions.ICatResponse response)
    where TCommand : Cat.Commands.Abstractions.ICatCommand;
```
#### Type parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(Cat.Responses.Abstractions.ICatResponse).TCommand'></a>

`TCommand`

The command type\.
#### Parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(Cat.Responses.Abstractions.ICatResponse).response'></a>

`response` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response every command of this type gets\.

#### Returns
[FakeCommandProcessor](FakeCommandProcessor.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_)'></a>

## FakeCommandProcessor\.Respond\<TCommand\>\(Func\<TCommand,ICatResponse\>\) Method

Sets the response for a command without a result, built from the command\.

```csharp
public Cat.UnitTesting.Commands.FakeCommandProcessor Respond<TCommand>(System.Func<TCommand,Cat.Responses.Abstractions.ICatResponse> respond)
    where TCommand : Cat.Commands.Abstractions.ICatCommand;
```
#### Type parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_).TCommand'></a>

`TCommand`

The command type\.
#### Parameters

<a name='Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_).respond'></a>

`respond` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TCommand](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_).TCommand 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\>\)\.TCommand')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the response\. It can also change the command, as a real handler would\.

#### Returns
[FakeCommandProcessor](FakeCommandProcessor.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor')  
The fake, so calls can be chained\.