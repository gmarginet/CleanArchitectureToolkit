import { useTranslation } from 'react-i18next'
import { Route, Routes } from 'react-router'
import { AdminCategoriesPage } from './pages/AdminCategoriesPage'
import { AdminCategoryPage } from './pages/AdminCategoryPage'
import { RequireLogin } from './auth/RequireLogin'
import { Layout } from './components/Layout'
import { BasketPage } from './pages/BasketPage'
import { BookDetailPage } from './pages/BookDetailPage'
import { BookListPage } from './pages/BookListPage'
import { AdminBookPage } from './pages/AdminBookPage'
import { OrderDetailPage } from './pages/OrderDetailPage'
import { OrdersPage } from './pages/OrdersPage'
import { LoginPage } from './pages/LoginPage'

export default function App() {
  const { t } = useTranslation()
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route index element={<BookListPage />} />
        <Route path="books/:id" element={<BookDetailPage />} />
        <Route path="basket" element={<BasketPage />} />
        <Route path="login" element={<LoginPage />} />
        <Route element={<RequireLogin />}>
          <Route path="orders" element={<OrdersPage />} />
          <Route path="orders/:id" element={<OrderDetailPage />} />
          <Route path="admin/books/new" element={<AdminBookPage />} />
          <Route path="admin/books/:id" element={<AdminBookPage />} />
          <Route path="admin/categories" element={<AdminCategoriesPage />} />
          <Route path="admin/categories/new" element={<AdminCategoryPage />} />
          <Route path="admin/categories/:id" element={<AdminCategoryPage />} />
        </Route>
        <Route path="*" element={<p>{t('common.pageNotFound')}</p>} />
      </Route>
    </Routes>
  )
}
