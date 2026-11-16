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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DAPPER](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Dapper\.Abstractions Assembly](index.md 'index')

## Cat\.Dapper\.Abstractions Namespace

Defines the contracts for database access with plain SQL: the factory that creates connections
and the session that holds one connection and its transaction for the length of a scope\.

| Interfaces | |
| :--- | :--- |
| [ICatDbConnectionFactory](ICatDbConnectionFactory.md 'Cat\.Dapper\.Abstractions\.ICatDbConnectionFactory') | Creates database connections\. A database project registers one factory, as a singleton, with the connection string\. |
| [ICatDbSession](ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession') | One database connection for the length of one scope, such as one request or one message\. The session takes the connection from [ICatDbConnectionFactory](ICatDbConnectionFactory.md 'Cat\.Dapper\.Abstractions\.ICatDbConnectionFactory') and opens it on first use, so a handler never opens or closes a connection\. A session is not thread safe\. |
