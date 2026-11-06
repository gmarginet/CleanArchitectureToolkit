const euro = new Intl.NumberFormat('en-IE', { style: 'currency', currency: 'EUR' })

/** Shows a price in euro. A book can have no price yet. */
export function formatPrice(price: number | null | undefined): string {
  return price === null || price === undefined ? 'No price yet' : euro.format(price)
}
