import { useState, type FormEvent } from 'react'
import { useTranslation } from 'react-i18next'
import { Link, useNavigate, useParams } from 'react-router'
import { useCategory, useSaveCategory } from '../api/books'
import { useIsAdmin } from '../auth/useIsAdmin'
import { ErrorMessage } from '../components/ErrorMessage'

interface Draft {
  name: string
  nameNl: string
}

/** Creates a category, or edits one when the route has an id. The admin fills the English name and the Dutch name. */
export function AdminCategoryPage() {
  const { t } = useTranslation()
  const { id } = useParams()
  const isAdmin = useIsAdmin()
  const category = useCategory(id ?? '')
  const save = useSaveCategory()
  const navigate = useNavigate()
  const [draft, setDraft] = useState<Draft | undefined>()

  const loaded: Draft | undefined = category.data
    ? { name: category.data.name, nameNl: category.data.nameNl ?? '' }
    : undefined
  const form: Draft = draft ?? loaded ?? { name: '', nameNl: '' }
  const editing = id !== undefined
  const waiting = editing && category.isPending

  function change(field: keyof Draft, value: string) {
    setDraft({ ...form, [field]: value })
  }

  function submit(event: FormEvent) {
    event.preventDefault()
    save.mutate(
      { id, name: form.name.trim(), nameNl: form.nameNl.trim() },
      { onSuccess: () => navigate('/admin/categories') },
    )
  }

  return (
    <>
      <p>
        <Link to="/admin/categories">{t('adminCategory.backToList')}</Link>
      </p>
      <h1>{editing ? t('adminCategory.editTitle') : t('adminCategory.newTitle')}</h1>
      {!isAdmin && (
        <p role="note" className="alert alert-info">
          {t('adminCategory.adminOnly')}
        </p>
      )}
      {waiting && <p>{t('adminCategory.loading')}</p>}
      {editing && category.isError && <ErrorMessage error={category.error} />}
      {!waiting && !(editing && category.isError) && (
        <form className="col-lg-6" onSubmit={submit}>
          <label className="d-block mb-3 fw-semibold">
            {t('adminCategory.name')}
            <input
              className="form-control fw-normal"
              value={form.name}
              maxLength={100}
              required
              onChange={(e) => change('name', e.target.value)}
            />
          </label>
          <label className="d-block mb-3 fw-semibold">
            {t('adminCategory.nameNl')}
            <input
              className="form-control fw-normal"
              value={form.nameNl}
              maxLength={100}
              onChange={(e) => change('nameNl', e.target.value)}
            />
            <span className="form-text fw-normal">{t('adminCategory.nameNlHint')}</span>
          </label>
          {save.isError && <ErrorMessage error={save.error} />}
          <button type="submit" className="btn btn-primary" disabled={save.isPending}>
            {save.isPending ? t('adminCategory.saving') : t('adminCategory.save')}
          </button>
        </form>
      )}
    </>
  )
}
