using System.Collections.Generic;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cat.Minimal.Api;

/// <summary>
/// The body of every failed response. It is a standard problem details object plus the CAT errors and a trace id.
/// </summary>
public class CatProblemDetails : ProblemDetails
{
    /// <summary>
    /// Creates an empty instance. Use it when you fill in the properties yourself.
    /// </summary>
    public CatProblemDetails()
    {

    }

    /// <summary>
    /// Creates problem details from a failed response.
    /// The status follows the response type: BadRequest gives 400, NotFound gives 404, Unauthorized gives 401.
    /// Every other failure gives 500.
    /// </summary>
    /// <param name="catResponse">The failed response.</param>
    /// <param name="instance">The path of the request.</param>
    /// <param name="catTraceId">The id to find this request in the logs.</param>
    public CatProblemDetails(ICatResponse catResponse, string instance, string catTraceId)
    {
        Detail = "Look at the CatErrors property for more details.";
        CatErrors = catResponse.ErrorList;
        Instance = instance;
        CatTraceId = catTraceId;

        switch (catResponse.Type)
        {
            case CatResponseType.Failed.BadRequest:
                Status = StatusCodes.Status400BadRequest;
                Title = "A bad request was made.";
                break;
            case CatResponseType.Failed.NotFound:
                Status = StatusCodes.Status404NotFound;
                Title = "The requested resource was not found.";
                break;
            case CatResponseType.Failed.Unauthorized:
                Status = StatusCodes.Status401Unauthorized;
                Title = "The request was not authorized.";
                break;
            default:
                Status = StatusCodes.Status500InternalServerError;
                Title = "An unexpected error occurred.";
                break;
        }
    }
    
    /// <summary>
    /// The errors of the failed response, each with a code, a message template and arguments.
    /// </summary>
    public IReadOnlyList<ICatError>? CatErrors { get; set; }

    /// <summary>
    /// The id to find this request in the logs.
    /// </summary>
    public string? CatTraceId { get; set; }
}