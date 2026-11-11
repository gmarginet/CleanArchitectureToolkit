using System;
using System.Collections.Generic;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Workflows;

/// <summary>The data of one run of the place order workflow. The steps read from it and write to it.</summary>
public class PlaceOrderState : ICatWorkflowState<PlaceOrderState>
{
    // Filled before the workflow runs.
    public string CustomerExternalId { get; set; } = "";

    /// <summary>The id of the new order. It exists from the start, so the create command gets it as input.</summary>
    public Guid OrderId { get; set; } = Guid.NewGuid();

    /// <summary>The moment the order is placed. The caller of the workflow sets it.</summary>
    public DateTime PlacedAt { get; set; }
    public string CustomerName { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public List<PlaceOrderLineState> Lines { get; set; } = [];

    // Filled by the steps.
    public Guid CustomerId { get; set; }
    public decimal Total { get; set; }

    /// <summary>What the create command returned. It is null until the order is created, and when the command failed.</summary>
    public OrderCreated? Created { get; set; }

    /// <summary>The order number from the database. Empty until the order is created.</summary>
    public string OrderNumber => Created?.OrderNumber ?? "";
    public bool StockReserved { get; set; }
    public bool StockUnavailable { get; set; }
    public Guid? OutOfStockBookId { get; set; }
    public bool PaymentApproved { get; set; }
    public bool PaymentUnavailable { get; set; }
    public string? PaymentReference { get; set; }

    /// <summary>One of the codes in <c>OrderCancelReasons</c>. Set before the cancelled event is published.</summary>
    public string CancelReason { get; set; } = "";
}

/// <summary>One line of the order being placed. The price step fills the unit price and the ISBN.</summary>
public class PlaceOrderLineState
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }

    /// <summary>The ISBN of the book. The price step fills it, because Inventory knows a book by its ISBN.</summary>
    public string Isbn { get; set; } = "";
    public decimal UnitPrice { get; set; }
}
