using Cat.Queries.Abstractions;

namespace ServiceName.CoreService.Queries;

/// <summary>The query ItemNameQuery. A Dapper handler in the Infrastructure project reads the rows with plain SQL.</summary>
public record ItemNameQuery : ICatQuery<IList<ItemNameRow>>;

/// <summary>One row of the result of <see cref="ItemNameQuery"/>. The names of the columns in the SQL are the names of the properties.</summary>
public class ItemNameRow
{
    public int Id { get; set; }
}
