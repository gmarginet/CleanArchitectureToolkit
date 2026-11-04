using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.CatalogService.Api.Extensions;

public static class CatalogEndpoints
{
    public static IEndpointRouteBuilder MapCatalogServiceEndpoints(this IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("/catalog");

        groupBuilder.MapCatGetList<BookSearchRequest, BookModel>("/books");
        groupBuilder.MapCatGet<BookGetRequest, BookModel>("/books/{bookId:guid}", CatResponseType.Ok, CatResponseType.NotFound);
        groupBuilder.MapCatPost<BookSaveRequest>("/books", CatResponseType.Ok);
        groupBuilder.MapCatGetList<CategoryGetListRequest, CategoryModel>("/categories");

        return builder;
    }
}
