import { afterEach, describe, expect, it } from 'vitest'
import { setAccessToken } from '../auth/accessToken'
import { bearerToken } from './client'

function send(): Request {
  const request = new Request('http://gateway/catalog/books')
  const result = bearerToken.onRequest?.({ request } as never)
  return (result as Request | undefined) ?? request
}

describe('bearerToken', () => {
  afterEach(() => setAccessToken(undefined))

  it('adds the token when a person is logged in', () => {
    setAccessToken('abc')

    expect(send().headers.get('Authorization')).toBe('Bearer abc')
  })

  it('adds nothing for an anonymous visitor', () => {
    expect(send().headers.has('Authorization')).toBe(false)
  })
})
