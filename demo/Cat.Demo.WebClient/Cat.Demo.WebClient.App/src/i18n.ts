import i18n from 'i18next'
import { initReactI18next } from 'react-i18next'
import en from './locales/en.json'
import nl from './locales/nl.json'

/** The languages of the shop. English is the default and the fallback. */
export const supportedLanguages = [
  { code: 'en', name: 'English', locale: 'en-IE' },
  { code: 'nl', name: 'Nederlands', locale: 'nl-NL' },
] as const

export type LanguageCode = (typeof supportedLanguages)[number]['code']

const storageKey = 'language'

function isSupported(code: string | null | undefined): code is LanguageCode {
  return supportedLanguages.some((language) => language.code === code)
}

/** The choice of the person, kept in this browser. It does not follow the person to another device. */
function storedLanguage(): LanguageCode | undefined {
  try {
    const stored = window.localStorage.getItem(storageKey)
    return isSupported(stored) ? stored : undefined
  } catch {
    return undefined
  }
}

/** Before the person picks a language, the language of the browser applies, when the shop has it. */
function browserLanguage(): LanguageCode {
  const code = (window.navigator.language ?? 'en').slice(0, 2).toLowerCase()
  return isSupported(code) ? code : 'en'
}

void i18n.use(initReactI18next).init({
  resources: { en: { translation: en }, nl: { translation: nl } },
  lng: storedLanguage() ?? browserLanguage(),
  fallbackLng: 'en',
  interpolation: { escapeValue: false },
  returnNull: false,
})

/** Switches the language and remembers it. The screens, the formats and the next calls follow. */
export async function setLanguage(code: LanguageCode): Promise<void> {
  try {
    window.localStorage.setItem(storageKey, code)
  } catch {
    // The choice still works for this visit when the browser keeps no storage.
  }
  await i18n.changeLanguage(code)
}

/** The language that the next call to the shop asks for, for the Accept-Language header. */
export function currentLanguage(): LanguageCode {
  return isSupported(i18n.language) ? i18n.language : 'en'
}

/** The locale for numbers and dates, such as `nl-NL`. */
export function currentLocale(): string {
  return supportedLanguages.find((language) => language.code === currentLanguage())?.locale ?? 'en-IE'
}

export default i18n
