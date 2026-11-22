import { useTranslation } from 'react-i18next'
import { Link, useParams } from 'react-router'
import { useIsAdmin } from '../auth/useIsAdmin'
import { useBook } from '../api/books'
import { ApiError } from '../api/errors'
import { AddToBasketButton } from '../components/AddToBasketButton'
import { ErrorMessage } from '../components/ErrorMessage'
import { formatPrice } from '../format'

export function BookDetailPage() {
  const { t } = useTranslation()
  const { id = '' } = useParams()
  const book = useBook(id)
  const isAdmin = useIsAdmin()

  return (
    <>
      <p>
        <Link to="/">{t('common.backToBooks')}</Link>
      </p>
      {book.isPending && <p>{t('books.loadingOne')}</p>}
      {book.isError &&
        (book.error instanceof ApiError && book.error.status === 404 ? (
          <p role="alert" className="alert alert-warning">
            {t('books.notFound')}
          </p>
        ) : (
          <ErrorMessage error={book.error} />
        ))}
      {book.isSuccess && (
        <article>
          <h1>{book.data.title}</h1>
          <dl className="row">
            <dt className="col-sm-3">{t('books.author')}</dt>
            <dd className="col-sm-9">{book.data.author}</dd>
            <dt className="col-sm-3">{t('common.category')}</dt>
            <dd className="col-sm-9">{book.data.categoryName}</dd>
            <dt className="col-sm-3">{t('books.isbn')}</dt>
            <dd className="col-sm-9">{book.data.isbn}</dd>
            <dt className="col-sm-3">{t('common.price')}</dt>
            <dd className="col-sm-9">{formatPrice(book.data.price, t('common.noPriceYet'))}</dd>
          </dl>
          <AddToBasketButton book={book.data} />
          {isAdmin && (
            <p>
              <Link to={`/admin/books/${book.data.id}`}>{t('books.edit')}</Link>
            </p>
          )}
        </article>
      )}
    </>
  )
}
