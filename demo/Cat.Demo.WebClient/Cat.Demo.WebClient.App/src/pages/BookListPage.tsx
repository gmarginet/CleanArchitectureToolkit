import { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { Link, useSearchParams } from 'react-router'
import { useBooks, useCategories } from '../api/books'
import { AddToBasketButton } from '../components/AddToBasketButton'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatPrice } from '../format'

export function BookListPage() {
  const { t } = useTranslation()
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
      <h1>{t('books.title')}</h1>
      <form
        role="search"
        className="row g-2 align-items-end mb-4"
        onSubmit={(event) => {
          event.preventDefault()
          update({ text: typed.trim() })
          setDraft(undefined)
        }}
      >
        <label className="col-sm-5 small">
          {t('books.searchLabel')}
          <input
            type="search"
            className="form-control"
            value={typed}
            onChange={(event) => setDraft(event.target.value)}
          />
        </label>
        <label className="col-sm-4 small">
          {t('common.category')}
          <select
            className="form-select"
            value={categoryId}
            onChange={(event) => update({ category: event.target.value })}
          >
            <option value="">{t('books.allCategories')}</option>
            {categories.data?.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </select>
        </label>
        <div className="col-sm-auto">
          <button type="submit" className="btn btn-primary">
            {t('common.search')}
          </button>
        </div>
      </form>

      {books.isPending && <p>{t('books.loadingList')}</p>}
      {books.isError && <ErrorMessage error={books.error} />}
      {books.isSuccess && books.data.length === 0 && <p>{t('books.none')}</p>}
      {books.isSuccess && books.data.length > 0 && (
        <ul className="list-group">
          {books.data.map((book) => (
            <li key={book.id ?? book.isbn} className="list-group-item d-flex justify-content-between gap-3">
              <div>
                <Link to={`/books/${book.id}`} className="fw-semibold">
                  {book.title}
                </Link>
                <div>{book.author}</div>
                <div className="small text-secondary">{book.categoryName}</div>
              </div>
              <div className="d-flex flex-column align-items-end gap-2 text-nowrap">
                <div>{formatPrice(book.price, t('common.noPriceYet'))}</div>
                <AddToBasketButton book={book} />
              </div>
            </li>
          ))}
        </ul>
      )}
    </>
  )
}
