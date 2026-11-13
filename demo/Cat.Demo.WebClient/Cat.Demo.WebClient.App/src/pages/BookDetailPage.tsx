import { Link, useParams } from 'react-router'
import { useIsAdmin } from '../auth/useIsAdmin'
import { useBook } from '../api/books'
import { ApiError } from '../api/errors'
import { AddToBasketButton } from '../components/AddToBasketButton'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatPrice } from '../format'

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
          <p role="alert" className="alert alert-warning">
            We could not find that book.
          </p>
        ) : (
          <ErrorMessage error={book.error} />
        ))}
      {book.isSuccess && (
        <article>
          <h1>{book.data.title}</h1>
          <dl className="row">
            <dt className="col-sm-3">Author</dt>
            <dd className="col-sm-9">{book.data.author}</dd>
            <dt className="col-sm-3">Category</dt>
            <dd className="col-sm-9">{book.data.categoryName}</dd>
            <dt className="col-sm-3">ISBN</dt>
            <dd className="col-sm-9">{book.data.isbn}</dd>
            <dt className="col-sm-3">Price</dt>
            <dd className="col-sm-9">{formatPrice(book.data.price)}</dd>
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
