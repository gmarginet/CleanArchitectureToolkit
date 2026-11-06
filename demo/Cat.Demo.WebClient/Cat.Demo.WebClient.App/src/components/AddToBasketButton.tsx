import { useBasket } from '../basket/useBasket'

interface AddToBasketButtonProps {
  book: { id?: string; title: string; price?: number | null }
}

/** Adds one copy to the basket. A book without a price cannot be bought yet. */
export function AddToBasketButton({ book }: AddToBasketButtonProps) {
  const basket = useBasket()
  const { id, price } = book

  if (!id || price === null || price === undefined) {
    return (
      <button type="button" disabled title="This book has no price yet">
        Add to basket
      </button>
    )
  }

  return (
    <button type="button" onClick={() => basket.add({ bookId: id, title: book.title, price })}>
      Add to basket
    </button>
  )
}
