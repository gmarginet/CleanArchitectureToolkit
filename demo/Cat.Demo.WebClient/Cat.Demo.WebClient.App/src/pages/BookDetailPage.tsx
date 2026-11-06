import { Link, useParams } from 'react-router'
import { useIsAdmin } from '../auth/useIsAdmin'
import { useBook } from '../api/books'
import { ApiError } from '../api/errors'
import { AddToBasketButton } from '../components/AddToBasketButton'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatPrice } from '../format'
import styles from './BookDetailPage.module.css'

export function BookDetailPage() {
  const { id = '' } = useParams()
  const book = useBook(id)
  const isAdmin = useIsAdmin()

  return (
    <>
      <p>
        <Link to="/">Back to the books</Link>
      </p>
      {book.isPending && <p>Loading the book</p>}
      {book.isError &&
        (book.error instanceof ApiError && book.error.status === 404 ? (
          <p role="alert">We could not find that book.</p>
        ) : (
          <ErrorMessage error={book.error} />
        ))}
      {book.isSuccess && (
        <article>
          <h1>{book.data.title}</h1>
          <dl className={styles.fields}>
            <dt>Author</dt>
            <dd>{book.data.author}</dd>
            <dt>Category</dt>
            <dd>{book.data.categoryName}</dd>
            <dt>ISBN</dt>
            <dd>{book.data.isbn}</dd>
            <dt>Price</dt>
            <dd>{formatPrice(book.data.price)}</dd>
          </dl>
          <AddToBasketButton book={book.data} />
          {isAdmin && (
            <p>
              <Link to={`/admin/books/${book.data.id}`}>Edit this book</Link>
            </p>
          )}
        </article>
      )}
    </>
  )
}
