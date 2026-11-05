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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index')

## System\.Runtime\.CompilerServices Namespace

| Classes | |
| :--- | :--- |
| [IsExternalInit](IsExternalInit.md 'System\.Runtime\.CompilerServices\.IsExternalInit') | Fix for Compile Error CS0518 Predefined type 'System\.Runtime\.CompilerServices\.IsExternalInit' is not defined or imported\.  Many developers think this is a bug in dotnet\. But unfortunately this is not a bug\. The IsExternalInit type is only included in the net5\.0 \(and future\) target frameworks\. When compiling against older target frameworks you will need to manually define this type\. [more info](https://developercommunity.visualstudio.com/t/error-cs0518-predefined-type-systemruntimecompiler/1244809 'https://developercommunity\.visualstudio\.com/t/error\-cs0518\-predefined\-type\-systemruntimecompiler/1244809') |
