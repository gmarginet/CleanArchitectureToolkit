using Cat.Demo.InventoryService.CoreService;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Tests;

[TestFixture]
public class StockChangeMapperTests
{
    private static Dictionary<string, object?> Row(int quantity, string isbn = "9780141036144", int warehouseId = 2) => new()
    {
        ["Id"] = 7,
        ["WarehouseId"] = warehouseId,
        ["Isbn"] = isbn,
        ["QuantityOnHand"] = quantity
    };

    [Test]
    public void Map_AnUpdate_ShouldCarryTheOldAndTheNewQuantityAndTheLimit()
    {
        var change = new CatChange
        {
            Table = StockChangeMapper.CaptureInstance,
            Operation = CatChangeOperation.Update,
            Keys = new Dictionary<string, object?> { ["Id"] = 7 },
            Old = Row(12),
            New = Row(4)
        };

        var message = StockChangeMapper.Map(change, 10);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Isbn, Is.EqualTo("9780141036144"));
            Assert.That(message.WarehouseId, Is.EqualTo(2));
            Assert.That(message.OldQuantity, Is.EqualTo(12));
            Assert.That(message.NewQuantity, Is.EqualTo(4));
            Assert.That(message.Limit, Is.EqualTo(10));
        }
    }

    [Test]
    public void Map_AnInsert_ShouldHaveNoOldQuantity()
    {
        var change = new CatChange { Operation = CatChangeOperation.Insert, New = Row(30) };

        var message = StockChangeMapper.Map(change, 10);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.OldQuantity, Is.Null);
            Assert.That(message.NewQuantity, Is.EqualTo(30));
        }
    }

    [Test]
    public void Map_ADelete_ShouldHaveNoNewQuantityAndTakeTheBookFromTheOldRow()
    {
        var change = new CatChange { Operation = CatChangeOperation.Delete, Old = Row(5, "9780261103573", 3) };

        var message = StockChangeMapper.Map(change, 10);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Isbn, Is.EqualTo("9780261103573"));
            Assert.That(message.WarehouseId, Is.EqualTo(3));
            Assert.That(message.OldQuantity, Is.EqualTo(5));
            Assert.That(message.NewQuantity, Is.Null);
        }
    }
}
