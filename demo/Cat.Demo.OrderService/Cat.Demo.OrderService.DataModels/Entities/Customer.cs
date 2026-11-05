using Cat.EFCore.Entities;

namespace Cat.Demo.OrderService.DataModels.Entities;

public class Customer : CatEntityBase
{
    /// <summary>The <c>sub</c> claim of the access token. It identifies the user in the identity provider.</summary>
    public required string ExternalId { get; set; }

    public required string Name { get; set; }
    public required string Email { get; set; }
}
