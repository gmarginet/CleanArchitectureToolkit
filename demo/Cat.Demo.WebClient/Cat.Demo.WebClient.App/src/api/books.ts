import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
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

export interface BookInput {
  id?: string
  isbn: string
  categoryId: string
  title: string
  author: string
  price: number
}

/** Creates a book, or updates it when the id is known. The catalog checks the ISBN and the role. */
export function useSaveBook() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (book: BookInput) => unwrap(catalogApi.POST('/catalog/books', { body: book })),
    onSuccess: () => {
      void queryClient.invalidateQueries({ queryKey: ['books'] })
      void queryClient.invalidateQueries({ queryKey: ['book'] })
    },
  })
}
