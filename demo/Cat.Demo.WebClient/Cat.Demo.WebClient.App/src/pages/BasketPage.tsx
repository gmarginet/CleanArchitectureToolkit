import { useAuth } from 'react-oidc-context'
import { Link } from 'react-router'
import { usePlaceOrder } from '../api/orders'
import { ErrorMessage } from '../components/ErrorMessage'
import { QuantityInput } from '../components/QuantityInput'
import { useBasket } from '../basket/useBasket'
import { formatAmount, formatPrice } from '../format'
import styles from './BasketPage.module.css'

export function BasketPage() {
  const basket = useBasket()
  const auth = useAuth()
  const placeOrder = usePlaceOrder()

  // The answer of the shop stays on the screen after the basket is emptied.
  if (placeOrder.isSuccess) {
    const order = placeOrder.data
    return (
      <>
        <h1>Thank you for your order</h1>
        <p role="status">
          Order <strong>{order.orderNumber}</strong> is <strong>{order.status}</strong>. The total is{' '}
          {formatAmount(order.total)}.
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

  function submit() {
    if (!auth.isAuthenticated) {
      // The basket is kept in this browser, so it is still here after the login.
      void auth.signinRedirect({ state: { returnTo: '/basket' } })
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
          <table className={styles.table}>
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
                    <button type="button" onClick={() => basket.remove(line.bookId)}>
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
          <p className={styles.note}>The shop confirms the price when you place the order.</p>

          {placeOrder.isError && <ErrorMessage error={placeOrder.error} />}

          <button type="button" disabled={placeOrder.isPending || auth.isLoading} onClick={submit}>
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
