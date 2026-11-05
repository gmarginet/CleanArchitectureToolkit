using System;
using System.Collections.Generic;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Workflows;

/// <summary>The data of one run of the place order workflow. The steps read from it and write to it.</summary>
public class PlaceOrderState : ICatWorkflowState<PlaceOrderState>
{
    // Filled before the workflow runs.
    public string CustomerExternalId { get; set; } = "";
    public string CustomerName { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public List<PlaceOrderLineState> Lines { get; set; } = [];

    // Filled by the steps.
    public Guid CustomerId { get; set; }
    public decimal Total { get; set; }
    public Guid OrderId { get; set; }
    public string OrderNumber { get; set; } = "";
    public bool StockReserved { get; set; }
    public Guid? OutOfStockBookId { get; set; }
    public bool PaymentApproved { get; set; }
    public string? PaymentReference { get; set; }

    /// <summary>One of the codes in <c>OrderCancelReasons</c>. Set before the cancelled event is published.</summary>
    public string CancelReason { get; set; } = "";
}

/// <summary>One line of the order being placed. The price step fills the unit price.</summary>
public class PlaceOrderLineState
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
