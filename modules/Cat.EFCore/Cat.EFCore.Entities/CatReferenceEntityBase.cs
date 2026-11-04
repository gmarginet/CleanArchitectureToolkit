namespace Cat.EFCore.Entities;

/// <summary>
/// Base class for entities that map a table owned by someone else.
/// Use it when the table belongs to another service, or to another part of the system, in a database you share.
/// Map the entity in your own <c>DbContext</c> so you can define foreign keys and navigations to it.
/// The table is excluded from migrations, so the owner keeps control of the schema.
/// Treat the entity as read-only, and do not use it for your own tables. Use <see cref="CatEntityBase"/> for those.
/// </summary>
public class CatReferenceEntityBase
{
    /// <summary>
    /// Gets or sets the unique id of the entity. It is the non-clustered primary key.
    /// </summary>
    public Guid Id { get; set; }
}
