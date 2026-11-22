import { useTranslation } from 'react-i18next'
import { useBasket } from '../basket/useBasket'

interface AddToBasketButtonProps {
  book: { id?: string; title: string; price?: number | null }
}

/** Adds one copy to the basket. A book without a price cannot be bought yet. */
export function AddToBasketButton({ book }: AddToBasketButtonProps) {
  const { t } = useTranslation()
  const basket = useBasket()
  const { id, price } = book

  if (!id || price === null || price === undefined) {
    return (
      <button type="button" className="btn btn-primary btn-sm" disabled title={t('basket.noPriceTitle')}>
        {t('basket.addToBasket')}
      </button>
    )
  }

  return (
    <button
      type="button"
      className="btn btn-primary btn-sm"
      onClick={() => basket.add({ bookId: id, title: book.title, price })}
    >
      {t('basket.addToBasket')}
    </button>
  )
}
