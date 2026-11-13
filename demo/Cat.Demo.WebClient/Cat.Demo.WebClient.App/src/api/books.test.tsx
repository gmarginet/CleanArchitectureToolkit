import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { renderHook, waitFor } from '@testing-library/react'
import type { ReactNode } from 'react'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { useBook } from './books'

vi.mock('./client', () => ({ catalogApi: { GET: vi.fn() } }))
import { catalogApi } from './client'

function wrapper({ children }: { children: ReactNode }) {
  return <QueryClientProvider client={new QueryClient()}>{children}</QueryClientProvider>
}

describe('useBook', () => {
  beforeEach(() => {
    vi.mocked(catalogApi.GET).mockReset()
  })

  it('asks the catalog for the book with the id', async () => {
    vi.mocked(catalogApi.GET).mockResolvedValue({ data: { id: 'b1', title: 'Dune' }, response: { ok: true } } as never)

    const { result } = renderHook(() => useBook('b1'), { wrapper })

    await waitFor(() => expect(result.current.isSuccess).toBe(true))
    expect(catalogApi.GET).toHaveBeenCalledWith('/catalog/books/{bookId}', { params: { path: { bookId: 'b1' } } })
  })

  it('makes no call without an id, because the empty id would ask for the whole list', () => {
    const { result } = renderHook(() => useBook(''), { wrapper })

    expect(catalogApi.GET).not.toHaveBeenCalled()
    expect(result.current.fetchStatus).toBe('idle')
    expect(result.current.data).toBeUndefined()
  })
})
