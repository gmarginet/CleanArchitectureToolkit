import { useTranslation } from 'react-i18next'
import { Link } from 'react-router'
import { useCategories } from '../api/books'
import { ErrorMessage } from '../components/ErrorMessage'

/** The categories for the admin, with a link to edit each one and to add a new one. */
export function AdminCategoriesPage() {
  const { t } = useTranslation()
  const categories = useCategories()

  return (
    <>
      <h1>{t('adminCategory.listTitle')}</h1>
      <p>
        <Link to="/admin/categories/new" className="btn btn-primary btn-sm">
          {t('adminCategory.new')}
        </Link>
      </p>
      {categories.isPending && <p>{t('common.loading')}</p>}
      {categories.isError && <ErrorMessage error={categories.error} />}
      {categories.isSuccess && (
        <ul className="list-group col-lg-6">
          {categories.data.map((category) => (
            <li key={category.id} className="list-group-item d-flex justify-content-between">
              <span>{category.name}</span>
              <Link to={`/admin/categories/${category.id}`}>{t('adminCategory.edit')}</Link>
            </li>
          ))}
        </ul>
      )}
    </>
  )
}
