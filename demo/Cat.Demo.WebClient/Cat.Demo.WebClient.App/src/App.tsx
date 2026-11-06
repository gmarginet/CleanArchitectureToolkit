import { Route, Routes } from 'react-router'
import { Layout } from './components/Layout'
import { BasketPage } from './pages/BasketPage'
import { BookDetailPage } from './pages/BookDetailPage'
import { BookListPage } from './pages/BookListPage'
import { AdminBookPage } from './pages/AdminBookPage'
import { OrderDetailPage } from './pages/OrderDetailPage'
import { OrdersPage } from './pages/OrdersPage'

export default function App() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route index element={<BookListPage />} />
        <Route path="books/:id" element={<BookDetailPage />} />
        <Route path="basket" element={<BasketPage />} />
        <Route path="orders" element={<OrdersPage />} />
        <Route path="orders/:id" element={<OrderDetailPage />} />
        <Route path="admin/books/new" element={<AdminBookPage />} />
        <Route path="admin/books/:id" element={<AdminBookPage />} />
        <Route path="*" element={<p>That page does not exist.</p>} />
      </Route>
    </Routes>
  )
}
