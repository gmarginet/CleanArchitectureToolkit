using Cat.Queries.Abstractions;
using RESULT_NAMESPACE;

namespace ServiceName.CoreService.Queries;

/// <summary>The query ItemNameQuery. Add the values that the handler needs.</summary>
public record ItemNameQuery(Guid Id) : ICatQuery<ResultEntity>;
