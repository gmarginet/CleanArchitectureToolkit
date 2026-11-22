import { Trans, useTranslation } from 'react-i18next'
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
  const { t } = useTranslation()
  const current = useOrder(placed.id as string, true)
  const order = current.data ?? placed
  const pending = order.status === pendingStatus
  const cancelled = order.status === 'Cancelled'
  const status = t(`orderStatus.${order.status}`, { defaultValue: order.status ?? '' })

  return (
    <>
      <h1>{cancelled ? t('placed.cancelled') : t('placed.thanks')}</h1>
      <p role="status" className={`alert ${cancelled ? 'alert-warning' : pending ? 'alert-info' : 'alert-success'}`}>
        <Trans
          i18nKey="placed.summary"
          values={{ number: order.orderNumber, status, total: formatAmount(order.total) }}
          components={{ bold: <strong /> }}
        />
        {pending && ` ${t('placed.takingPayment')}`}
      </p>
      <p>
        <Link to={`/orders/${order.id}`}>{t('placed.seeOrder')}</Link>
      </p>
      <p>
        <Link to="/">{t('common.backToBooks')}</Link>
      </p>
    </>
  )
}

export function BasketPage() {
  const { t } = useTranslation()
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
      <h1>{t('basket.title')}</h1>
      {basket.lines.length === 0 ? (
        <p>
          {t('basket.empty')} <Link to="/">{t('basket.findBook')}</Link>
        </p>
      ) : (
        <>
          <table className="table align-middle">
            <thead>
              <tr>
                <th>{t('common.book')}</th>
                <th>{t('common.quantity')}</th>
                <th className={styles.number}>{t('common.price')}</th>
                <th className={styles.number}>{t('basket.lineTotal')}</th>
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
                      label={t('basket.quantityOf', { title: line.title })}
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
                      {t('basket.remove')}
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <th colSpan={3}>{t('common.total')}</th>
                <th className={styles.number}>{formatPrice(basket.total)}</th>
                <td />
              </tr>
            </tfoot>
          </table>
          <p className="form-text">{t('basket.priceNote')}</p>

          {placeOrder.isError && <ErrorMessage error={placeOrder.error} />}

          <button type="button" className="btn btn-primary" disabled={placeOrder.isPending || auth.isLoading} onClick={submit}>
            {placeOrder.isPending
              ? t('basket.placing')
              : auth.isAuthenticated
                ? t('basket.place')
                : t('basket.logInToPlace')}
          </button>
        </>
      )}
    </>
  )
}
