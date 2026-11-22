import '@testing-library/jest-dom/vitest'
import { cleanup } from '@testing-library/react'
import { afterEach } from 'vitest'
import i18n from '../i18n'

// The tests read the English texts. A test of another language switches and puts English back itself.
void i18n.changeLanguage('en')

afterEach(() => cleanup())
