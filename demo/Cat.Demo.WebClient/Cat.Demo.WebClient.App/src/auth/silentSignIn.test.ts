import { beforeEach, describe, expect, it } from 'vitest'
import { forgetSignedIn, rememberSignedIn, shouldSignInSilently, wasSignedIn, type SignInState } from './silentSignIn'

const loggedOutAfterRefresh: SignInState = {
  isLoading: false,
  isAuthenticated: false,
  hasError: false,
  isNavigating: false,
  wasSignedIn: true,
}

describe('shouldSignInSilently', () => {
  it('signs in again after a refresh of a logged in person', () => {
    expect(shouldSignInSilently(loggedOutAfterRefresh)).toBe(true)
  })

  it.each([
    ['the person never logged in', { wasSignedIn: false }],
    ['the library is still loading', { isLoading: true }],
    ['the person is logged in', { isAuthenticated: true }],
    ['the last attempt failed', { hasError: true }],
    ['a redirect is already running', { isNavigating: true }],
  ])('does not when %s', (_name, change) => {
    expect(shouldSignInSilently({ ...loggedOutAfterRefresh, ...change })).toBe(false)
  })
})

describe('the signed in flag', () => {
  beforeEach(() => sessionStorage.clear())

  it('is remembered and forgotten', () => {
    expect(wasSignedIn()).toBe(false)

    rememberSignedIn()
    expect(wasSignedIn()).toBe(true)

    forgetSignedIn()
    expect(wasSignedIn()).toBe(false)
  })
})
