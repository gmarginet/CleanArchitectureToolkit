import { useState } from 'react'
import { Link, useSearchParams } from 'react-router'
import { useBooks, useCategories } from '../api/books'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatPrice } from '../format'
import styles from './BookListPage.module.css'

export function BookListPage() {
  // The search lives in the address, so a search can be bookmarked and the back button works.
  const [searchParams, setSearchParams] = useSearchParams()
  const text = searchParams.get('text') ?? ''
  const categoryId = searchParams.get('category') ?? ''
  // What the person is typing. Without a draft the box shows the text of the address, so it follows the address
  // when the page is reached by a link, a back button or the return from the login.
  const [draft, setDraft] = useState<string>()
  const typed = draft ?? text

  const books = useBooks({ text, categoryId })
  const categories = useCategories()

  function update(next: { text?: string; category?: string }) {
    const params = new URLSearchParams(searchParams)
    for (const [key, value] of Object.entries(next)) {
      if (value) params.set(key, value)
      else params.delete(key)
    }
    setSearchParams(params)
  }

  return (
    <>
      <h1>Books</h1>
      <form
        role="search"
        className={styles.search}
        onSubmit={(event) => {
          event.preventDefault()
          update({ text: typed.trim() })
          setDraft(undefined)
        }}
      >
        <label>
          Search
          <input type="search" value={typed} onChange={(event) => setDraft(event.target.value)} />
        </label>
        <label>
          Category
          <select value={categoryId} onChange={(event) => update({ category: event.target.value })}>
            <option value="">All categories</option>
            {categories.data?.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </select>
        </label>
        <button type="submit">Search</button>
      </form>

      {books.isPending && <p>Loading books</p>}
      {books.isError && <ErrorMessage error={books.error} />}
      {books.isSuccess && books.data.length === 0 && <p>No books found.</p>}
      {books.isSuccess && books.data.length > 0 && (
        <ul className={styles.list}>
          {books.data.map((book) => (
            <li key={book.id ?? book.isbn} className={styles.book}>
              <div>
                <Link to={`/books/${book.id}`} className={styles.title}>
                  {book.title}
                </Link>
                <div>{book.author}</div>
                <div className={styles.category}>{book.categoryName}</div>
              </div>
              <div className={styles.price}>{formatPrice(book.price)}</div>
            </li>
          ))}
        </ul>
      )}
    </>
  )
}
