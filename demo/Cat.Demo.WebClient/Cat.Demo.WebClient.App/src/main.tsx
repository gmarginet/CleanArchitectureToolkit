import { QueryClientProvider } from '@tanstack/react-query'
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter } from 'react-router'
import { createQueryClient } from './api/queryClient'
import App from './App.tsx'
import { AuthProviderWithRouter } from './auth/AuthProviderWithRouter'
import { BasketProvider } from './basket/BasketProvider'
import i18n from './i18n'
import 'bootstrap/dist/css/bootstrap.min.css'

const queryClient = createQueryClient()

// The names of categories come from the server in the language of the call. A new language asks for them again.
i18n.on('languageChanged', (language) => {
  document.documentElement.lang = language
  void queryClient.invalidateQueries()
})
document.documentElement.lang = i18n.language

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <AuthProviderWithRouter>
          <BasketProvider>
            <App />
          </BasketProvider>
        </AuthProviderWithRouter>
      </BrowserRouter>
    </QueryClientProvider>
  </StrictMode>,
)
