import { useState, type FormEvent } from 'react'
import { useTranslation } from 'react-i18next'
import { Link, useNavigate, useParams } from 'react-router'
import { useBook, useCategories, useSaveBook } from '../api/books'
import { useIsAdmin } from '../auth/useIsAdmin'
import { ErrorMessage } from '../components/ErrorMessage'

interface Draft {
  isbn: string
  title: string
  author: string
  categoryId: string
  price: string
}

/** Creates a book, or edits one when the route has an id. The link to it only shows for admins. */
export function AdminBookPage() {
  const { t } = useTranslation()
  const { id } = useParams()
  const isAdmin = useIsAdmin()
  const book = useBook(id ?? '')
  const categories = useCategories()
  const save = useSaveBook()
  const navigate = useNavigate()
  const [draft, setDraft] = useState<Draft | undefined>()

  const loaded: Draft | undefined = book.data
    ? {
        isbn: book.data.isbn,
        title: book.data.title,
        author: book.data.author,
        categoryId: book.data.categoryId ?? '',
        price: book.data.price === null || book.data.price === undefined ? '' : String(book.data.price),
      }
    : undefined
  const form: Draft = draft ?? loaded ?? { isbn: '', title: '', author: '', categoryId: '', price: '' }
  const editing = id !== undefined
  const waiting = editing && book.isPending

  function change(field: keyof Draft, value: string) {
    setDraft({ ...form, [field]: value })
  }

  function submit(event: FormEvent) {
    event.preventDefault()
    save.mutate(
      {
        id,
        isbn: form.isbn.trim(),
        title: form.title.trim(),
        author: form.author.trim(),
        categoryId: form.categoryId,
        price: Number(form.price),
      },
      { onSuccess: () => navigate(id ? `/books/${id}` : '/') },
    )
  }

  return (
    <>
      <p>
        <Link to={editing ? `/books/${id}` : '/'}>{t('common.back')}</Link>
      </p>
      <h1>{editing ? t('adminBook.editTitle') : t('adminBook.newTitle')}</h1>
      {!isAdmin && (
        <p role="note" className="alert alert-info">
          {t('adminBook.adminOnly')}
        </p>
      )}
      {waiting && <p>{t('books.loadingOne')}</p>}
      {editing && book.isError && <ErrorMessage error={book.error} />}
      {!waiting && !(editing && book.isError) && (
        <form className="col-lg-6" onSubmit={submit}>
          <label className="d-block mb-3 fw-semibold">
            {t('adminBook.isbn')}
            <input
              className="form-control fw-normal"
              value={form.isbn}
              maxLength={13}
              required
              onChange={(e) => change('isbn', e.target.value)}
            />
          </label>
          <label className="d-block mb-3 fw-semibold">
            {t('adminBook.bookTitle')}
            <input
              className="form-control fw-normal"
              value={form.title}
              maxLength={200}
              required
              onChange={(e) => change('title', e.target.value)}
            />
          </label>
          <label className="d-block mb-3 fw-semibold">
            {t('adminBook.author')}
            <input
              className="form-control fw-normal"
              value={form.author}
              maxLength={200}
              required
              onChange={(e) => change('author', e.target.value)}
            />
          </label>
          <label className="d-block mb-3 fw-semibold">
            {t('adminBook.category')}
            <select
              className="form-select fw-normal"
              value={form.categoryId}
              required
              onChange={(e) => change('categoryId', e.target.value)}
            >
              <option value="">{t('adminBook.chooseCategory')}</option>
              {(categories.data ?? []).map((category) => (
                <option key={category.id} value={category.id}>
                  {category.name}
                </option>
              ))}
            </select>
          </label>
          <label className="d-block mb-3 fw-semibold">
            {t('adminBook.price')}
            <input
              className="form-control fw-normal"
              type="number"
              min="0"
              step="0.01"
              value={form.price}
              required
              onChange={(e) => change('price', e.target.value)}
            />
          </label>
          {save.isError && <ErrorMessage error={save.error} />}
          <button type="submit" className="btn btn-primary" disabled={save.isPending}>
            {save.isPending ? t('adminBook.saving') : t('adminBook.save')}
          </button>
        </form>
      )}
    </>
  )
}
