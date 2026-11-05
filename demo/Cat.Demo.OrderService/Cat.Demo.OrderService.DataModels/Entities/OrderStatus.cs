using Cat.EFCore.Entities;

namespace Cat.Demo.OrderService.DataModels.Entities;

public class OrderStatus : CatEntityBase
{
    public required string Code { get; set; }
}
