using System.Linq;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Workflows.Steps;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;

namespace Cat.Demo.OrderService.CoreService.Workflows;

/// <summary>
/// The place order process: find the customer, price the lines, create the order, reserve stock,
/// take payment and confirm.
/// A failure after the order is created cancels the order. The canceled event does the cleanup.
/// </summary>
public class PlaceOrderWorkflow : ICatWorkflow<PlaceOrderState>
{
    public void Build(ICatWorkflowBuilder<PlaceOrderState> builder)
    {
        // 1. The customer. The first order of a user creates the customer.
        builder.ProcessCommand<PlaceOrderState, CustomerCreateOrUpdateCommand>()
            .Input(s => s.CustomerExternalId, step => step.Command.ExternalId)
            .Input(s => s.CustomerName, step => step.Command.Name)
            .Input(s => s.CustomerEmail, step => step.Command.Email)
            .Output(step => step.Command.CustomerId, s => s.CustomerId);

        // 2. The prices, and the total over all lines.
        builder.Run<PlaceOrderState, PriceLinesStep>();
        builder.Foreach(s => s.Lines, loop =>
        {
            loop.Run(item => item.ParentWorkflowState.Total += item.CurrentItem.Quantity * item.CurrentItem.UnitPrice);
        });

        // 3. The order. It gets its number and status Pending in one transaction.
        builder.ProcessCommand<PlaceOrderState, OrderCreateCommand>()
            .Input(s => s.CustomerId, step => step.Command.CustomerId)
            .Input(s => s.Total, step => step.Command.Total)
            .Input(s => s.Lines.Select(l => new OrderCreateLine(l.BookId, l.Quantity, l.UnitPrice)).ToList(), step => step.Command.Lines)
            .Output(step => step.Command.OrderId, s => s.OrderId)
            .Output(step => step.Command.OrderNumber, s => s.OrderNumber);

        // 4. The stock. Out of stock cancels the order and ends the workflow.
        builder.Run<PlaceOrderState, ReserveStockStep>();
        builder.If(s => !s.StockReserved, then =>
        {
            then.Set(s => s.CancelReason, s => OrderCancelReasons.OutOfStock);
            then.Run<PlaceOrderState, PublishOrderCancelledStep>();
            then.Run(s => CatResponse.BadRequest<CatStepExecutionResult>(
                OrderErrorDefinitions.OutOfStock.CreateCatError(s.OutOfStockBookId, s.OrderNumber)));
        });

        // 5. The payment. A payment service that cannot answer cancels the order and ends the workflow, and nothing is saved.
        // An answer is saved when it is a decline too. A decline cancels the order and ends the workflow.
        builder.Run<PlaceOrderState, TakePaymentStep>();
        builder.If(s => s.PaymentUnavailable, then =>
        {
            then.Set(s => s.CancelReason, s => OrderCancelReasons.PaymentUnavailable);
            then.Run<PlaceOrderState, PublishOrderCancelledStep>();
            then.Run(s => CatResponse.BadRequest<CatStepExecutionResult>(
                OrderErrorDefinitions.PaymentUnavailable.CreateCatError(s.OrderNumber)));
        });
        builder.ProcessCommand<PlaceOrderState, PaymentSaveCommand>()
            .Input(s => s.OrderId, step => step.Command.OrderId)
            .Input(s => s.Total, step => step.Command.Amount)
            .Input(s => s.PaymentApproved, step => step.Command.Approved);
        builder.If(s => !s.PaymentApproved, then =>
        {
            then.Set(s => s.CancelReason, s => OrderCancelReasons.PaymentDeclined);
            then.Run<PlaceOrderState, PublishOrderCancelledStep>();
            then.Run(s => CatResponse.BadRequest<CatStepExecutionResult>(
                OrderErrorDefinitions.PaymentDeclined.CreateCatError(s.OrderNumber)));
        });

        // 6. Confirm. The subscribers set the status.
        builder.Run<PlaceOrderState, PublishOrderConfirmedStep>();
    }
}
