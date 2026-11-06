import { Route, Routes } from 'react-router'
import { Layout } from './components/Layout'
import { BasketPage } from './pages/BasketPage'
import { BookDetailPage } from './pages/BookDetailPage'
import { BookListPage } from './pages/BookListPage'

export default function App() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route index element={<BookListPage />} />
        <Route path="books/:id" element={<BookDetailPage />} />
        <Route path="basket" element={<BasketPage />} />
        <Route path="*" element={<p>That page does not exist.</p>} />
      </Route>
    </Routes>
  )
}
