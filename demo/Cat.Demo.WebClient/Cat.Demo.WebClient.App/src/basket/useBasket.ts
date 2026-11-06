import { useContext } from 'react'
import { BasketContext, type Basket } from './context'

export function useBasket(): Basket {
  const basket = useContext(BasketContext)
  if (!basket) {
    throw new Error('useBasket needs a BasketProvider above it.')
  }
  return basket
}
