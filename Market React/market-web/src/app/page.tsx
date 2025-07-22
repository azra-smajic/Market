import styles from "./globals.css";
import LoginPage from "./Login/LoginPage";
export default function Home() {
  return (
    <div className={styles.page}>
      <main className={styles.main}>
        <LoginPage></LoginPage>
      </main>
    </div>
  );
}
