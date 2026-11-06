import { useQuery } from '@tanstack/react-query'
import { catalogApi } from './client'
import { unwrap } from './errors'

export interface BookFilter {
  text?: string
  categoryId?: string
}

export function useBooks(filter: BookFilter) {
  return useQuery({
    queryKey: ['books', filter.text ?? '', filter.categoryId ?? ''],
    queryFn: () =>
      unwrap(
        catalogApi.GET('/catalog/books', {
          params: { query: { Text: filter.text || undefined, CategoryId: filter.categoryId || undefined } },
        }),
      ),
  })
}

export function useBook(bookId: string) {
  return useQuery({
    queryKey: ['book', bookId],
    queryFn: () => unwrap(catalogApi.GET('/catalog/books/{bookId}', { params: { path: { bookId } } })),
  })
}

export function useCategories() {
  return useQuery({
    queryKey: ['categories'],
    queryFn: () => unwrap(catalogApi.GET('/catalog/categories')),
  })
}
