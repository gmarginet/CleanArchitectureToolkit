using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Validators;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Demo.CatalogService.CoreService.Validators;

public class BookModelValidator : ICatValidator<BookModel>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public BookModelValidator(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }

    public void Build(ICatValidatorBuilder<BookModel> validator)
    {
        validator.AddPropertyRules(m => m.Isbn, b =>
        {
            b.NotEmpty();
            b.ExactLength(13);
            b.MustAsync(IsbnIsNotUsedByAnotherBookAsync);
        });

        validator.AddPropertyRules(m => m.Title, b =>
        {
            b.NotEmpty();
            b.MaximumLength(200);
        });

        validator.AddPropertyRules(m => m.Author, b =>
        {
            b.NotEmpty();
            b.MaximumLength(200);
        });

        validator.AddPropertyRules(m => m.CategoryId, b =>
        {
            b.NotEmpty();
        });

        validator.AddPropertyRules(m => m.Price, b =>
        {
            b.GreaterThanOrEqualTo(0m);
        });
    }

    private async Task<List<ICatValidatorError>> IsbnIsNotUsedByAnotherBookAsync(
        string isbn,
        string fieldName,
        BookModel book,
        CancellationToken cancellationToken)
    {
        // The other rules report an empty ISBN. There is nothing to look up.
        if (string.IsNullOrWhiteSpace(isbn)) return CatValidatorResult.Valid();

        var excludeBookId = book.Id == Guid.Empty ? (Guid?)null : book.Id;
        var response = await _queryProcessor.ProcessAsync(new CheckIsbnExistsQuery(isbn, excludeBookId), cancellationToken);

        if (!response.IsSucceeded)
        {
            throw new InvalidOperationException($"The ISBN check failed with a {response.Type} response.");
        }

        return response.Value
            ? CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    CatalogErrorDefinitions.IsbnAlreadyExists.Code,
                    fieldName,
                    CatalogErrorDefinitions.IsbnAlreadyExists.Message,
                    isbn))
            : CatValidatorResult.Valid();
    }
}
