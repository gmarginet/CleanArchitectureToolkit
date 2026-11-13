import { describe, expect, it } from 'vitest'
import { readReturnTo, loginState } from './loginRoute'

describe('readReturnTo', () => {
  it('gives back a path of this app', () => {
    expect(readReturnTo(loginState('/orders?x=1'))).toBe('/orders?x=1')
  })

  it.each([undefined, null, {}, { returnTo: 5 }, { returnTo: 'https://evil.example' }, { returnTo: '//evil.example' }])(
    'gives the book list for %j',
    (state) => {
      expect(readReturnTo(state)).toBe('/')
    },
  )

  it('never returns to the login page itself', () => {
    expect(readReturnTo(loginState('/login'))).toBe('/')
  })
})
