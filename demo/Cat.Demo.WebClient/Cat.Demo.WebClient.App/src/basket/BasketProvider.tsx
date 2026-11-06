import { useEffect, useMemo, useReducer, type ReactNode } from 'react'
import { basketCount, basketReducer, basketTotal, loadBasket, saveBasket } from './basketState'
import { BasketContext, type Basket } from './context'

/** Keeps the basket in this browser, so a page refresh or the trip to the login does not empty it. */
export function BasketProvider({ children }: { children: ReactNode }) {
  const [lines, dispatch] = useReducer(basketReducer, undefined, loadBasket)

  useEffect(() => saveBasket(lines), [lines])

  const basket = useMemo<Basket>(
    () => ({
      lines,
      count: basketCount(lines),
      total: basketTotal(lines),
      add: (line) => dispatch({ type: 'add', line }),
      setQuantity: (bookId, quantity) => dispatch({ type: 'setQuantity', bookId, quantity }),
      remove: (bookId) => dispatch({ type: 'remove', bookId }),
      clear: () => dispatch({ type: 'clear' }),
    }),
    [lines],
  )

  return <BasketContext value={basket}>{children}</BasketContext>
}
