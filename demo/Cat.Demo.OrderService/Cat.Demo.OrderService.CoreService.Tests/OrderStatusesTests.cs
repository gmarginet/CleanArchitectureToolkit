using Cat.Demo.OrderService.DataModels.Entities;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class OrderStatusesTests
{
    [TestCase(OrderStatuses.PendingCode)]
    [TestCase(OrderStatuses.ConfirmedCode)]
    [TestCase(OrderStatuses.CancelledCode)]
    public void GetId_ShouldGiveADifferentIdPerCode(string code)
    {
        var ids = new[] { OrderStatuses.PendingCode, OrderStatuses.ConfirmedCode, OrderStatuses.CancelledCode }.Select(OrderStatuses.GetId);

        Assert.That(ids.Distinct().Count(), Is.EqualTo(3));
        Assert.That(OrderStatuses.GetId(code), Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void GetId_ForAnUnknownCode_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => OrderStatuses.GetId("Shipped"));
    }
}
