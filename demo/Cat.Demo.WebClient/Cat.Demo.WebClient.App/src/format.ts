const euro = new Intl.NumberFormat('en-IE', { style: 'currency', currency: 'EUR' })

/** Shows a price in euro. A book can have no price yet. */
export function formatPrice(price: number | null | undefined): string {
  return price === null || price === undefined ? 'No price yet' : euro.format(price)
}

/** Shows an amount of the Orders service. Its OpenAPI document allows a number or a string for it. */
export function formatAmount(amount: number | string | null | undefined): string {
  const value = Number(amount)
  return amount === null || amount === undefined || Number.isNaN(value) ? '' : euro.format(value)
}
