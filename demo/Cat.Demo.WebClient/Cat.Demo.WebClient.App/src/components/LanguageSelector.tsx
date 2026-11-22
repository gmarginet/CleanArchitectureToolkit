import { useTranslation } from 'react-i18next'
import { currentLanguage, setLanguage, supportedLanguages, type LanguageCode } from '../i18n'

/** Lets the person pick the language. The name of a language is written in that language, so everyone finds theirs. */
export function LanguageSelector() {
  const { t, i18n } = useTranslation()
  // Reading i18n.language makes the component render again when the language changes.
  const selected = i18n.language ? currentLanguage() : 'en'

  return (
    <select
      className="form-select form-select-sm w-auto"
      aria-label={t('nav.language')}
      value={selected}
      onChange={(event) => void setLanguage(event.target.value as LanguageCode)}
    >
      {supportedLanguages.map((language) => (
        <option key={language.code} value={language.code}>
          {language.name}
        </option>
      ))}
    </select>
  )
}
