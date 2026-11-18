using Cat.Demo.OrderService.DataModels.Entities;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class OrderStatusesTests
{
    [TestCase(OrderStatuses.PendingCode)]
    [TestCase(OrderStatuses.ConfirmedCode)]
    [TestCase(OrderStatuses.CancelledCode)]
    [TestCase(OrderStatuses.ShippedCode)]
    public void GetId_ShouldGiveADifferentIdPerCode(string code)
    {
        var ids = new[] { OrderStatuses.PendingCode, OrderStatuses.ConfirmedCode, OrderStatuses.CancelledCode, OrderStatuses.ShippedCode }.Select(OrderStatuses.GetId);

        Assert.That(ids.Distinct().Count(), Is.EqualTo(4));
        Assert.That(OrderStatuses.GetId(code), Is.Not.EqualTo(Guid.Empty));
    }

    [TestCase(OrderStatuses.PendingCode, true)]
    [TestCase(OrderStatuses.ConfirmedCode, true)]
    [TestCase(OrderStatuses.ShippedCode, false)]
    [TestCase(OrderStatuses.CancelledCode, false)]
    [TestCase("Delivered", false)]
    public void CanCancel_ShouldAllowOnlyPendingAndConfirmed(string code, bool expected)
    {
        Assert.That(OrderStatuses.CanCancel(code), Is.EqualTo(expected));
    }

    [Test]
    public void GetId_ForAnUnknownCode_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => OrderStatuses.GetId("Delivered"));
    }
}
