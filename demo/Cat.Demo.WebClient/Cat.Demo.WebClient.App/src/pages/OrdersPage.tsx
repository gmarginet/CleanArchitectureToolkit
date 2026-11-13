import { useAuth } from 'react-oidc-context'
import { Link } from 'react-router'
import { useOrders } from '../api/orders'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatAmount } from '../format'
import styles from './BasketPage.module.css'

/** The orders of the logged in person, newest first. */
export function OrdersPage() {
  const auth = useAuth()
  const orders = useOrders(auth.isAuthenticated)

  const sorted = [...(orders.data ?? [])].sort((a, b) => (b.placedAt ?? '').localeCompare(a.placedAt ?? ''))

  return (
    <>
      <h1>My orders</h1>
      {orders.isPending && <p>Loading your orders</p>}
      {orders.isError && <ErrorMessage error={orders.error} />}
      {orders.isSuccess && sorted.length === 0 && <p>You have no orders yet.</p>}
      {sorted.length > 0 && (
        <table className={styles.table}>
          <thead>
            <tr>
              <th>Order</th>
              <th>Placed</th>
              <th>Status</th>
              <th className={styles.number}>Total</th>
            </tr>
          </thead>
          <tbody>
            {sorted.map((order) => (
              <tr key={order.id}>
                <td>
                  <Link to={`/orders/${order.id}`}>{order.orderNumber}</Link>
                </td>
                <td>{order.placedAt ? new Date(order.placedAt).toLocaleString('en-IE') : ''}</td>
                <td>{order.status}</td>
                <td className={styles.number}>{formatAmount(order.total)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </>
  )
}
