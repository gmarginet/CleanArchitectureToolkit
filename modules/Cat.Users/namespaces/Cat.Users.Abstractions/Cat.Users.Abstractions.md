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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.USERS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Users\.Abstractions Assembly](index.md 'index')

## Cat\.Users\.Abstractions Namespace

The contracts for the user of a request or a message: the user, the accessor that holds it and a plain implementation for the anonymous and the system user\.

| Classes | |
| :--- | :--- |
| [CatUser](CatUser.md 'Cat\.Users\.Abstractions\.CatUser') | A plain, immutable [ICatUser](ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')\. It is the anonymous user, the system user of a worker, or any user a developer builds by hand\. |

| Interfaces | |
| :--- | :--- |
| [ICatUser](ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser') | The user behind a request or a message\. Business logic knows only this interface, never the HTTP context or the token\. |
| [ICatUserAccessor](ICatUserAccessor.md 'Cat\.Users\.Abstractions\.ICatUserAccessor') | Holds the user of the current scope\. A worker, such as the event processor or the scheduler, sets the user for the work it starts\. |
