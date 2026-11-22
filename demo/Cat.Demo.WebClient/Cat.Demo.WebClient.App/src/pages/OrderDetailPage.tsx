import { useQueries } from '@tanstack/react-query'
import { Trans, useTranslation } from 'react-i18next'
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
  const { t } = useTranslation()
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
        <p>{t('orders.logInToSee')}</p>
        <button
          type="button"
          disabled={auth.isLoading}
          className="btn btn-primary"
          onClick={() => void auth.signinRedirect({ state: { returnTo: `/orders/${id}` } })}
        >
          {t('nav.logIn')}
        </button>
      </>
    )
  }

  return (
    <>
      <p>
        <Link to="/orders">{t('orders.backToOrders')}</Link>
      </p>
      {order.isPending && <p>{t('orders.loadingOne')}</p>}
      {order.isError &&
        (order.error instanceof ApiError && order.error.status === 404 ? (
          <p role="alert" className="alert alert-warning">
            {t('orders.notFound')}
          </p>
        ) : (
          <ErrorMessage error={order.error} />
        ))}
      {order.isSuccess && (
        <article>
          <h1>{t('orders.heading', { number: order.data.orderNumber })}</h1>
          <p>
            <Trans
              i18nKey="orders.statusLine"
              values={{ status: t(`orderStatus.${order.data.status}`, { defaultValue: order.data.status ?? '' }) }}
              components={{ bold: <strong /> }}
            />
          </p>
          <table className="table">
            <thead>
              <tr>
                <th>{t('common.book')}</th>
                <th className={styles.number}>{t('common.quantity')}</th>
                <th className={styles.number}>{t('common.price')}</th>
                <th className={styles.number}>{t('orders.lineTotal')}</th>
              </tr>
            </thead>
            <tbody>
              {lines.map((line, index) => (
                <tr key={line.bookId}>
                  <td>
                    <Link to={`/books/${line.bookId}`}>{books[index]?.data?.title ?? t('orders.bookFallback')}</Link>
                  </td>
                  <td className={styles.number}>{line.quantity}</td>
                  <td className={styles.number}>{formatAmount(line.unitPrice)}</td>
                  <td className={styles.number}>{formatAmount(Number(line.unitPrice) * Number(line.quantity))}</td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <th colSpan={3}>{t('common.total')}</th>
                <th className={styles.number}>{formatAmount(order.data.total)}</th>
              </tr>
            </tfoot>
          </table>

          {cancel.isError && <ErrorMessage error={cancel.error} />}
          {cancel.isSuccess && (
            <p role="status" className="alert alert-success">
              {t('orders.cancelled')}
            </p>
          )}
          <button type="button" className="btn btn-outline-danger" disabled={cancel.isPending || !order.data.canCancel} onClick={() => cancel.mutate()}>
            {cancel.isPending ? t('orders.cancelling') : t('orders.cancel')}
          </button>
        </article>
      )}
    </>
  )
}
