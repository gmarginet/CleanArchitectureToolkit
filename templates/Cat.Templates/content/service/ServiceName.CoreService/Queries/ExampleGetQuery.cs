using Cat.Queries.Abstractions;
using ServiceName.DataModels.Entities;

namespace ServiceName.CoreService.Queries;

public record ExampleGetQuery(Guid ExampleId) : ICatQuery<ExampleItem>;
