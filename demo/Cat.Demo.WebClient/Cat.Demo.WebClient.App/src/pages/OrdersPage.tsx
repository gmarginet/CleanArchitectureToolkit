import { useTranslation } from 'react-i18next'
import { useAuth } from 'react-oidc-context'
import { Link } from 'react-router'
import { useOrders } from '../api/orders'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatAmount, formatDateTime } from '../format'
import styles from './BasketPage.module.css'

/** The orders of the logged in person, newest first. */
export function OrdersPage() {
  const { t } = useTranslation()
  const auth = useAuth()
  const orders = useOrders(auth.isAuthenticated)

  const sorted = [...(orders.data ?? [])].sort((a, b) => (b.placedAt ?? '').localeCompare(a.placedAt ?? ''))

  return (
    <>
      <h1>{t('orders.title')}</h1>
      {orders.isPending && <p>{t('orders.loading')}</p>}
      {orders.isError && <ErrorMessage error={orders.error} />}
      {orders.isSuccess && sorted.length === 0 && <p>{t('orders.none')}</p>}
      {sorted.length > 0 && (
        <table className="table">
          <thead>
            <tr>
              <th>{t('orders.order')}</th>
              <th>{t('orders.placed')}</th>
              <th>{t('orders.status')}</th>
              <th className={styles.number}>{t('orders.total')}</th>
            </tr>
          </thead>
          <tbody>
            {sorted.map((order) => (
              <tr key={order.id}>
                <td>
                  <Link to={`/orders/${order.id}`}>{order.orderNumber}</Link>
                </td>
                <td>{order.placedAt ? formatDateTime(order.placedAt) : ''}</td>
                <td>{t(`orderStatus.${order.status}`, { defaultValue: order.status ?? '' })}</td>
                <td className={styles.number}>{formatAmount(order.total)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </>
  )
}
