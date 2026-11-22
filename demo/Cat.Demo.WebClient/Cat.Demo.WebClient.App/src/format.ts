import { currentLocale } from './i18n'

/** Formats an amount in euro in the language of the person, such as `€12.50` or `€ 12,50`. */
function euro(amount: number): string {
  return new Intl.NumberFormat(currentLocale(), { style: 'currency', currency: 'EUR' }).format(amount)
}

/** Shows a price in euro. A book can have no price yet. */
export function formatPrice(price: number | null | undefined, noPrice = 'No price yet'): string {
  return price === null || price === undefined ? noPrice : euro(price)
}

/** Shows an amount of the Orders service. Its OpenAPI document allows a number or a string for it. */
export function formatAmount(amount: number | string | null | undefined): string {
  const value = Number(amount)
  return amount === null || amount === undefined || Number.isNaN(value) ? '' : euro(value)
}

/** Shows a moment in the language of the person. */
export function formatDateTime(value: string): string {
  return new Date(value).toLocaleString(currentLocale())
}
