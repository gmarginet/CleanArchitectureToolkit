import { useState, type FormEvent } from 'react'
import { Link, useNavigate, useParams } from 'react-router'
import { useBook, useCategories, useSaveBook } from '../api/books'
import { useIsAdmin } from '../auth/useIsAdmin'
import { ErrorMessage } from '../components/ErrorMessage'
import styles from './AdminBookPage.module.css'

interface Draft {
  isbn: string
  title: string
  author: string
  categoryId: string
  price: string
}

/** Creates a book, or edits one when the route has an id. The link to it only shows for admins. */
export function AdminBookPage() {
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
        <Link to={editing ? `/books/${id}` : '/'}>Back</Link>
      </p>
      <h1>{editing ? 'Edit book' : 'New book'}</h1>
      {!isAdmin && <p role="note">Only an admin can save a book. The shop checks this again when you save.</p>}
      {waiting && <p>Loading the book</p>}
      {editing && book.isError && <ErrorMessage error={book.error} />}
      {!waiting && !(editing && book.isError) && (
        <form className={styles.form} onSubmit={submit}>
          <label>
            ISBN
            <input value={form.isbn} maxLength={13} required onChange={(e) => change('isbn', e.target.value)} />
          </label>
          <label>
            Title
            <input value={form.title} maxLength={200} required onChange={(e) => change('title', e.target.value)} />
          </label>
          <label>
            Author
            <input value={form.author} maxLength={200} required onChange={(e) => change('author', e.target.value)} />
          </label>
          <label>
            Category
            <select value={form.categoryId} required onChange={(e) => change('categoryId', e.target.value)}>
              <option value="">Choose a category</option>
              {(categories.data ?? []).map((category) => (
                <option key={category.id} value={category.id}>
                  {category.name}
                </option>
              ))}
            </select>
          </label>
          <label>
            Price in euro
            <input
              type="number"
              min="0"
              step="0.01"
              value={form.price}
              required
              onChange={(e) => change('price', e.target.value)}
            />
          </label>
          {save.isError && <ErrorMessage error={save.error} />}
          <button type="submit" disabled={save.isPending}>
            {save.isPending ? 'Saving the book' : 'Save book'}
          </button>
        </form>
      )}
    </>
  )
}
