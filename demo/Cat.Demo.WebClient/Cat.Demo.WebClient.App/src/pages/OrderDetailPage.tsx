import { useQueries } from '@tanstack/react-query'
import { useAuth } from 'react-oidc-context'
import { Link, useParams } from 'react-router'
import { catalogApi } from '../api/client'
import { ApiError, unwrap } from '../api/errors'
import { useCancelOrder, useOrder } from '../api/orders'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatAmount } from '../format'
import styles from './BasketPage.module.css'

/** One order with its lines and a cancel button. The titles come from the catalog, one cached call per book. */
export function OrderDetailPage() {
  const { id = '' } = useParams()
  const auth = useAuth()
  const order = useOrder(id, auth.isAuthenticated)
  const cancel = useCancelOrder(id)

  const lines = order.data?.lines ?? []
  const books = useQueries({
    queries: lines.map((line) => ({
      queryKey: ['book', line.bookId],
      queryFn: () =>
        unwrap(catalogApi.GET('/catalog/books/{bookId}', { params: { path: { bookId: line.bookId as string } } })),
    })),
  })

  if (!auth.isAuthenticated) {
    return (
      <>
        <p>Log in to see this order.</p>
        <button
          type="button"
          disabled={auth.isLoading}
          onClick={() => void auth.signinRedirect({ state: { returnTo: `/orders/${id}` } })}
        >
          Log in
        </button>
      </>
    )
  }

  return (
    <>
      <p>
        <Link to="/orders">Back to my orders</Link>
      </p>
      {order.isPending && <p>Loading the order</p>}
      {order.isError &&
        (order.error instanceof ApiError && order.error.status === 404 ? (
          <p role="alert">We could not find that order.</p>
        ) : (
          <ErrorMessage error={order.error} />
        ))}
      {order.isSuccess && (
        <article>
          <h1>Order {order.data.orderNumber}</h1>
          <p>
            Status: <strong>{order.data.status}</strong>
          </p>
          <table className={styles.table}>
            <thead>
              <tr>
                <th>Book</th>
                <th className={styles.number}>Quantity</th>
                <th className={styles.number}>Price</th>
                <th className={styles.number}>Line total</th>
              </tr>
            </thead>
            <tbody>
              {lines.map((line, index) => (
                <tr key={line.bookId}>
                  <td>
                    <Link to={`/books/${line.bookId}`}>{books[index]?.data?.title ?? 'Book'}</Link>
                  </td>
                  <td className={styles.number}>{line.quantity}</td>
                  <td className={styles.number}>{formatAmount(line.unitPrice)}</td>
                  <td className={styles.number}>{formatAmount(Number(line.unitPrice) * Number(line.quantity))}</td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <th colSpan={3}>Total</th>
                <th className={styles.number}>{formatAmount(order.data.total)}</th>
              </tr>
            </tfoot>
          </table>

          {cancel.isError && <ErrorMessage error={cancel.error} />}
          {cancel.isSuccess && <p role="status">The order is cancelled.</p>}
          <button type="button" disabled={cancel.isPending} onClick={() => cancel.mutate()}>
            {cancel.isPending ? 'Cancelling the order' : 'Cancel order'}
          </button>
        </article>
      )}
    </>
  )
}
