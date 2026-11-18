import { describe, expect, it } from 'vitest'
import { confirmedPollInterval, orderPollInterval, pendingPollInterval } from './orders'

describe('orderPollInterval', () => {
  it('polls a pending order often', () => {
    expect(orderPollInterval('Pending')).toBe(pendingPollInterval)
  })

  it('polls a confirmed order slowly, until it is shipped', () => {
    expect(orderPollInterval('Confirmed')).toBe(confirmedPollInterval)
  })

  it.each(['Shipped', 'Cancelled', undefined])('does not poll an order with status %s', (status) => {
    expect(orderPollInterval(status)).toBe(false)
  })
})
