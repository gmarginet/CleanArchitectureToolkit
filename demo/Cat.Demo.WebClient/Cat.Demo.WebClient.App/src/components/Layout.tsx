import { Link, Outlet } from 'react-router'
import styles from './Layout.module.css'

export function Layout() {
  return (
    <>
      <header className={styles.header}>
        <Link to="/" className={styles.brand}>
          CAT Bookshop
        </Link>
        <nav>
          <Link to="/">Books</Link>
        </nav>
      </header>
      <main className={styles.main}>
        <Outlet />
      </main>
    </>
  )
}
