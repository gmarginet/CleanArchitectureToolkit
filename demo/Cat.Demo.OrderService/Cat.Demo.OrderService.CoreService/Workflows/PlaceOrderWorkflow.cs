using System.Linq;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Workflows.Steps;
using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Cat.Sagas.Extensions;

namespace Cat.Demo.OrderService.CoreService.Workflows;

/// <summary>
/// The place order process: find the customer, price the lines, create the order, reserve stock,
/// take payment and confirm.
/// A failure after the order is created cancels the order. The canceled event does the cleanup.
/// </summary>
public class PlaceOrderWorkflow : ICatWorkflow<PlaceOrderState>
{
    private readonly PlaceOrderOptions _options;

    public PlaceOrderWorkflow(PlaceOrderOptions options)
    {
        _options = options;
    }

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
        // The state supplies the id and the time. The command returns the number, which the database hands out.
        builder.ProcessCommand<PlaceOrderState, OrderCreateCommand, OrderCreated>()
            .Input(s => s.OrderId, step => step.Command.OrderId)
            .Input(s => s.PlacedAt, step => step.Command.PlacedAt)
            .Input(s => s.CustomerId, step => step.Command.CustomerId)
            .Input(s => s.Total, step => step.Command.Total)
            .Input(s => s.Lines.Select(l => new OrderCreateLine(l.BookId, l.Quantity, l.UnitPrice)).ToList(), step => step.Command.Lines)
            .Output(step => step.Response!.Value, s => s.Created);

        // 4. The stock. An inventory service that cannot answer cancels the order and ends the workflow.
        // Out of stock cancels the order and ends the workflow too.
        builder.Run<PlaceOrderState, ReserveStockStep>();
        builder.If(s => s.StockUnavailable, then =>
        {
            then.Set(s => s.CancelReason, s => OrderCancelReasons.StockUnavailable);
            then.Run<PlaceOrderState, PublishOrderCancelledStep>();
            then.Run(s => CatResponse.BadRequest<CatStepExecutionResult>(
                OrderErrorDefinitions.StockUnavailable.CreateCatError(s.OrderNumber)));
        });
        builder.If(s => !s.StockReserved, then =>
        {
            then.Set(s => s.CancelReason, s => OrderCancelReasons.OutOfStock);
            then.Run<PlaceOrderState, PublishOrderCancelledStep>();
            then.Run(s => CatResponse.BadRequest<CatStepExecutionResult>(
                OrderErrorDefinitions.OutOfStock.CreateCatError(s.OutOfStockBookId, s.OrderNumber)));
        });

        // 5. The payment. The workflow sends the request to Payment and stops here. Its state is saved, and the caller gets its answer.
        // The answer of Payment resumes the workflow, even after a restart. No answer in time cancels the order and ends the workflow.
        // An answer is saved when it is a decline too. A decline cancels the order and ends the workflow.
        builder.SendAndWait<PlaceOrderState, TakePayment, PaymentProcessed>("payment", _options.PaymentTimeout)
            .Input(s => s.OrderNumber, step => step.Request.OrderNumber)
            .Input(s => s.Total, step => step.Request.Amount)
            .Output(step => step.Answer != null && step.Answer.Approved, s => s.PaymentApproved)
            .Output(step => step.TimedOut, s => s.PaymentUnavailable)
            .Output(step => step.Answer != null ? step.Answer.Reference : null, s => s.PaymentReference);
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
