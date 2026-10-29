<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Minimal\.Api](index.md 'index')

## Cat\.Minimal\.Api Namespace

Turns service requests into minimal API endpoints\.
Failed responses become problem details, and unexpected exceptions are caught and reported the same way\.

| Classes | |
| :--- | :--- |
| [CatEndpointRouteBuilderExtensions](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions') | Maps service requests to minimal API endpoints\. |
| [CatExceptionHandler](CatExceptionHandler.md 'Cat\.Minimal\.Api\.CatExceptionHandler') | Catches unexpected exceptions, logs them and answers with a 500 [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')\. |
| [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') | The body of every failed response\. It is a standard problem details object plus the CAT errors and a trace id\. |
