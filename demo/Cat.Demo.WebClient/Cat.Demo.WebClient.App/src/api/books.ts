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
    // The form for a new book has no id. Without this the empty id asks for the whole list.
    enabled: bookId !== '',
  })
}

export function useCategories() {
  return useQuery({
    queryKey: ['categories'],
    queryFn: () => unwrap(catalogApi.GET('/catalog/categories')),
  })
}

/** One category with its English name and its Dutch name, for the admin. Only an admin can read it. */
export function useCategory(categoryId: string) {
  return useQuery({
    queryKey: ['category', categoryId],
    queryFn: () => unwrap(catalogApi.GET('/catalog/categories/{categoryId}', { params: { path: { categoryId } } })),
    // The form for a new category has no id.
    enabled: categoryId !== '',
  })
}

export interface CategoryInput {
  id?: string
  name: string
  nameNl?: string
}

/** Creates a category, or updates it when the id is known. The Dutch name is saved with it. */
export function useSaveCategory() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (category: CategoryInput) =>
      unwrap(catalogApi.POST('/catalog/categories', { body: category })),
    onSuccess: () => {
      // The book lists show the name of a category, so they are asked for again too.
      void queryClient.invalidateQueries({ queryKey: ['categories'] })
      void queryClient.invalidateQueries({ queryKey: ['category'] })
      void queryClient.invalidateQueries({ queryKey: ['books'] })
      void queryClient.invalidateQueries({ queryKey: ['book'] })
    },
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
