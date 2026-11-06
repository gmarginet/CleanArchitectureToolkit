import { renderHook } from '@testing-library/react'
import { describe, expect, it, vi } from 'vitest'
import { useIsAdmin } from './useIsAdmin'

vi.mock('react-oidc-context', () => ({ useAuth: vi.fn() }))
import { useAuth } from 'react-oidc-context'

function withProfile(profile: object | undefined) {
  vi.mocked(useAuth).mockReturnValue({ user: profile ? { profile } : undefined } as never)
  return renderHook(() => useIsAdmin()).result.current
}

describe('useIsAdmin', () => {
  it('is true for the admin role', () => expect(withProfile({ roles: ['admin'] })).toBe(true))
  it('is false without the role', () => expect(withProfile({ roles: ['user'] })).toBe(false))
  it('is false without roles or a user', () => {
    expect(withProfile({})).toBe(false)
    expect(withProfile(undefined)).toBe(false)
  })
})
