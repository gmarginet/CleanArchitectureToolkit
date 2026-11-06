using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Cat.Demo.ServiceDefaults;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.CatalogService.Api.Extensions;

public static class CatalogEndpoints
{
    public static IEndpointRouteBuilder MapCatalogServiceEndpoints(this IEndpointRouteBuilder builder, bool requireLogin = false)
    {
        var catalogBuilder = builder.MapGroup("/catalog");

        var booksBuilder = catalogBuilder.MapGroup("/books");
        booksBuilder.MapCatGetList<BookSearchRequest, BookModel>("/");
        booksBuilder.MapCatGetList<BookPriceListRequest, BookPriceModel>("/prices", CatResponseType.Ok, CatResponseType.NotFound);
        booksBuilder.MapCatGet<BookGetRequest, BookModel>("/{bookId:guid}", CatResponseType.Ok, CatResponseType.NotFound);
        var save = booksBuilder.MapCatPost<BookSaveRequest>("/", CatResponseType.Ok);
        if (requireLogin)
        {
            save.RequireAuthorization(AuthenticationExtensions.AdminPolicy);
        }
        
        catalogBuilder.MapCatGetList<CategoryGetListRequest, CategoryModel>("/categories");

        return builder;
    }
}
