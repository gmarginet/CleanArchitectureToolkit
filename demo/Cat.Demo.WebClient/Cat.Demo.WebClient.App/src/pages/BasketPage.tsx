import { useAuth } from 'react-oidc-context'
import { Link, useNavigate } from 'react-router'
import { pendingStatus, usePlaceOrder, useOrder } from '../api/orders'
import { loginPath, loginState } from '../auth/loginRoute'
import { ErrorMessage } from '../components/ErrorMessage'
import { QuantityInput } from '../components/QuantityInput'
import { useBasket } from '../basket/useBasket'
import { formatAmount, formatPrice } from '../format'
import styles from './BasketPage.module.css'

type PlacedOrderData = ReturnType<typeof usePlaceOrder>['data']

/**
 * The screen after the order is placed. The shop answers at once with the order in status Pending, and takes the
 * payment in the background. The page asks for the order again until the status changes, and shows the new status.
 */
function PlacedOrder({ placed }: { placed: NonNullable<PlacedOrderData> }) {
  const current = useOrder(placed.id as string, true)
  const order = current.data ?? placed
  const pending = order.status === pendingStatus
  const cancelled = order.status === 'Cancelled'

  return (
    <>
      <h1>{cancelled ? 'Your order was cancelled' : 'Thank you for your order'}</h1>
      <p role="status" className={`alert ${cancelled ? 'alert-warning' : pending ? 'alert-info' : 'alert-success'}`}>
        Order <strong>{order.orderNumber}</strong> is <strong>{order.status}</strong>. The total is {formatAmount(order.total)}.
        {pending && ' We are taking the payment. This page updates by itself.'}
      </p>
      <p>
        <Link to={`/orders/${order.id}`}>See this order</Link>
      </p>
      <p>
        <Link to="/">Back to the books</Link>
      </p>
    </>
  )
}

export function BasketPage() {
  const basket = useBasket()
  const auth = useAuth()
  const placeOrder = usePlaceOrder()
  const navigate = useNavigate()

  // The answer of the shop stays on the screen after the basket is emptied.
  if (placeOrder.isSuccess) {
    return <PlacedOrder placed={placeOrder.data} />
  }

  function submit() {
    if (!auth.isAuthenticated) {
      // The basket is kept in this browser, so it is still here after the login.
      void navigate(loginPath, { state: loginState('/basket') })
      return
    }
    placeOrder.mutate(
      basket.lines.map((line) => ({ bookId: line.bookId, quantity: line.quantity })),
      { onSuccess: () => basket.clear() },
    )
  }

  return (
    <>
      <h1>Basket</h1>
      {basket.lines.length === 0 ? (
        <p>
          Your basket is empty. <Link to="/">Find a book</Link>
        </p>
      ) : (
        <>
          <table className="table align-middle">
            <thead>
              <tr>
                <th>Book</th>
                <th>Quantity</th>
                <th className={styles.number}>Price</th>
                <th className={styles.number}>Total</th>
                <th />
              </tr>
            </thead>
            <tbody>
              {basket.lines.map((line) => (
                <tr key={line.bookId}>
                  <td>
                    <Link to={`/books/${line.bookId}`}>{line.title}</Link>
                  </td>
                  <td>
                    <QuantityInput
                      label={`Quantity of ${line.title}`}
                      quantity={line.quantity}
                      onChange={(quantity) => basket.setQuantity(line.bookId, quantity)}
                    />
                  </td>
                  <td className={styles.number}>{formatPrice(line.price)}</td>
                  <td className={styles.number}>{formatPrice(line.price * line.quantity)}</td>
                  <td>
                    <button
                      type="button"
                      className="btn btn-outline-danger btn-sm"
                      onClick={() => basket.remove(line.bookId)}
                    >
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <th colSpan={3}>Total</th>
                <th className={styles.number}>{formatPrice(basket.total)}</th>
                <td />
              </tr>
            </tfoot>
          </table>
          <p className="form-text">The shop confirms the price when you place the order.</p>

          {placeOrder.isError && <ErrorMessage error={placeOrder.error} />}

          <button type="button" className="btn btn-primary" disabled={placeOrder.isPending || auth.isLoading} onClick={submit}>
            {placeOrder.isPending
              ? 'Placing the order'
              : auth.isAuthenticated
                ? 'Place order'
                : 'Log in to place your order'}
          </button>
        </>
      )}
    </>
  )
}
