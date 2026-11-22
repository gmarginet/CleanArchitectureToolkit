import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { afterEach, describe, expect, it } from 'vitest'
import { acceptLanguage } from './api/client'
import { toApiError } from './api/errors'
import { LanguageSelector } from './components/LanguageSelector'
import { formatAmount } from './format'
import i18n, { currentLanguage, setLanguage } from './i18n'
import en from './locales/en.json'
import nl from './locales/nl.json'

afterEach(async () => {
  window.localStorage.clear()
  await i18n.changeLanguage('en')
})

function keys(value: object, prefix = ''): string[] {
  return Object.entries(value).flatMap(([key, child]) =>
    typeof child === 'object' && child !== null ? keys(child, `${prefix}${key}.`) : [`${prefix}${key}`],
  )
}

describe('the language files', () => {
  it('give Dutch a text for every English text', () => {
    const dutch = new Set(keys(nl))
    expect(keys(en).filter((key) => !dutch.has(key))).toEqual([])
  })
})

describe('setLanguage', () => {
  it('switches the language and remembers it', async () => {
    await setLanguage('nl')

    expect(currentLanguage()).toBe('nl')
    expect(window.localStorage.getItem('language')).toBe('nl')
    expect(i18n.t('nav.books')).toBe('Boeken')
  })

  it('formats amounts in the locale of the language', async () => {
    await setLanguage('nl')

    expect(formatAmount(12.5)).toContain('12,50')
  })
})

describe('the Accept-Language header', () => {
  it('carries the chosen language', async () => {
    await setLanguage('nl')
    const request = new Request('http://localhost/catalog/books')

    await acceptLanguage.onRequest?.({ request } as never)

    expect(request.headers.get('Accept-Language')).toBe('nl')
  })
})

describe('error messages', () => {
  const body = {
    catErrors: [{ code: 'DEM-ORD-1005', message: 'You must be logged in to do this.', arguments: [] }],
  }

  it('keep the English message of the server in English', () => {
    expect(toApiError(401, body).message).toBe('You must be logged in to do this.')
  })

  it('use the Dutch text of a known code in Dutch', async () => {
    await setLanguage('nl')

    expect(toApiError(401, body).message).toBe('Je moet ingelogd zijn om dit te doen.')
  })

  it('keep the message of the server for a code without a translation', async () => {
    await setLanguage('nl')
    const unknown = { catErrors: [{ code: 'XXX-1', message: 'Plain message.', arguments: [] }] }

    expect(toApiError(400, unknown).message).toBe('Plain message.')
  })
})

describe('LanguageSelector', () => {
  it('switches the language when the person picks another one', async () => {
    render(<LanguageSelector />)

    await userEvent.selectOptions(screen.getByRole('combobox', { name: 'Language' }), 'nl')

    expect(currentLanguage()).toBe('nl')
  })
})
