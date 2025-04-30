# 🥋 Aplikasi Pendaftaran Peserta Pencak Silat

Aplikasi desktop berbasis Windows Forms (C#) untuk mencatat data peserta kejuaraan pencak silat. Aplikasi ini menggunakan **MySQL** sebagai basis data untuk menyimpan informasi peserta.


# Aplikasi Pendaftaran Peserta Silat

Aplikasi ini digunakan untuk mengelola pendaftaran peserta kejuaraan silat. Aplikasi berbasis Windows Form (WinForms) ini menyediakan fitur login, pendaftaran akun, form input data peserta, dan tampilan data pesilat yang telah mendaftar.

---

## 🚀 Fitur Aplikasi

1. **Form Login**
   - Pengguna masuk dengan nama dan password.
   - Jika belum memiliki akun, dapat menuju halaman Register.

2. **Form Register**
   - Untuk membuat akun baru.
   - Setelah mendaftar, pengguna diarahkan kembali ke Form Login.

3. **Form Dashboard**
   - Halaman utama setelah berhasil login.
   - Menyediakan tombol navigasi ke:
     - Form Pendaftaran Peserta
     - Data Pesilat
     - Logout (kembali ke Form Login)

4. **Form Pendaftaran Peserta**
   - Formulir pengisian data peserta:
     - Nama Peserta
     - Kontingen
     - Umur & Berat Badan
     - Prestasi / Permasalahan
     - Kelas Pertandingan
   - Tombol "Kirim" untuk menyimpan data (belum terhubung ke database, bisa dikembangkan).
   - Tombol "Kembali" untuk kembali ke Dashboard atau Login.

5. **Form Data Pesilat**
   - Menampilkan daftar peserta yang telah mendaftar.
   - Dapat dikembangkan untuk menampilkan data dari database atau file.

---

## 🧭 Alur Navigasi

```text
Form Login 
  └── [Belum punya akun?] → Form Register 
                            └── [Register] → kembali ke Form Login
  └── [Login Berhasil] → Dashboard
        ├── [Pendaftaran] → Form Pendaftaran
        ├── [Data Pesilat] → Form Data
        └── [Logout] → kembali ke Form Login


## 🖥 Teknologi

- C# (.NET Framework / WinForms)
- MySQL
- MySQL Connector/NET (`MySql.Data`)
- Visual Studio 2019 / 2022



