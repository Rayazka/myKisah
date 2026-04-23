# myKisah 🌱

**myKisah** adalah web application berbasis **Blazor**, **C#**, dan **.NET** yang membantu mahasiswa membangun kebiasaan positif melalui **journaling**, **habit tracking**, serta **dukungan sosial** dari buddy dan character companion.

Aplikasi ini berfokus pada **konsistensi pengguna** dalam menjalankan aktivitas harian seperti belajar, ibadah, dan self-improvement dengan pendekatan reflektif dan suportif.

---

## 📌 Latar Belakang Masalah

Banyak mahasiswa gagal menjaga konsistensi kebiasaan karena:
- Tidak memiliki sistem tracking yang terstruktur
- Tidak adanya support system atau accountability partner

Data penggunaan aplikasi seperti Duolingo menunjukkan bahwa **reminder** dan **virtual companion** mampu meningkatkan **retensi harian pengguna**. myKisah mengadopsi pendekatan serupa untuk mendukung pembentukan kebiasaan positif.

---

## 🎯 Solusi yang Ditawarkan

Fitur utama dalam myKisah:

- 📔 **Journaling harian** sebagai media refleksi diri
- ✅ **Habit tracking** untuk memonitor progres kebiasaan
- 🤝 **Buddy system** untuk dukungan sosial
- 🎭 **Character companion** untuk meningkatkan engagement

---

## 👥 Target User

- Mahasiswa usia **18–25 tahun**
- Individu yang ingin membangun kebiasaan positif
- Komunitas kampus atau circle kecil

---

## 💎 Value Proposition

- Meningkatkan **konsistensi aktivitas harian**
- Memberikan **dukungan sosial**
- Membuat aktivitas tracking lebih **menarik & engaging**

---

## 🔄 Alur Aplikasi

1. **User Registration & Login**  
   User membuat akun dan login ke sistem

2. **Setup Awal**
   - Memilih habit
   - Memilih character companion

3. **Daily Activity**
   - Mengisi journal harian
   - Update checklist habit

4. **Buddy Interaction**
   - Menambahkan buddy
   - Melihat journal & progres habit buddy

5. **Companion Feedback**
   - Respon character terhadap journal
   - Feedback terhadap progres habit

6. **Progress Monitoring**
   - Riwayat journal
   - Streak habit
   - Aktivitas buddy

---

## 📏 Business Rules

### 1. User

| ID | Business Rule |
|----|--------------|
| U-01 | Setiap user memiliki akun yang unik |
| U-02 | Email user tidak boleh duplikat |
| U-03 | User wajib login untuk mengakses fitur aplikasi |

### 2. Journal

| ID | Business Rule |
|----|--------------|
| J-01 | User hanya dapat mengakses journal miliknya sendiri |
| J-02 | Journal harus memiliki isi minimal 1 karakter |
| J-03 | Journal terikat pada satu tanggal |

### 3. Habit

| ID | Business Rule |
|----|--------------|
| H-01 | Habit hanya dapat dibuat oleh user |
| H-02 | Setiap habit memiliki status harian (done / not done) |
| H-03 | Streak bertambah jika habit dilakukan berturut-turut |

### 4. Buddy System

| ID | Business Rule |
|----|--------------|
| B-01 | User hanya dapat memiliki maksimal 1 buddy (MVP) |
| B-02 | Buddy dapat melihat journal user |
| B-03 | Buddy dapat melihat data habit user |
| B-04 | Relasi buddy harus mutual (saling approve) |

### 5. Character Companion

| ID | Business Rule |
|----|--------------|
| C-01 | User hanya dapat memilih 1 character aktif |
| C-02 | Character memberikan respon berdasarkan kondisi user |
| C-03 | Respon diambil dari predefined (table-driven data) |

---

## ✅ Functional Requirements

### FR-01 User Management

| ID | Functional Requirement |
|----|------------------------|
| FR-01.1 | User dapat melakukan registrasi akun |
| FR-01.2 | User dapat login ke sistem |
| FR-01.3 | User dapat melihat profil |
| FR-01.4 | User dapat mengubah profil |
| FR-01.5 | User dapat menghapus akun |

### FR-02 Journal Management

| ID | Functional Requirement |
|----|------------------------|
| FR-02.1 | User dapat membuat journal |
| FR-02.2 | User dapat melihat daftar journal |
| FR-02.3 | User dapat mengedit journal |
| FR-02.4 | User dapat menghapus journal |

### FR-03 Habit Tracking

| ID | Functional Requirement |
|----|------------------------|
| FR-03.1 | User dapat membuat habit |
| FR-03.2 | User dapat melihat daftar habit |
| FR-03.3 | User dapat mengupdate status habit harian |
| FR-03.4 | User dapat menghapus habit |

### FR-04 Buddy System

| ID | Functional Requirement |
|----|------------------------|
| FR-04.1 | User dapat menambahkan buddy |
| FR-04.2 | User dapat menerima request buddy |
| FR-04.3 | User dapat menolak request buddy |
| FR-04.4 | User dapat melihat journal buddy |
| FR-04.5 | User dapat melihat progres habit buddy |

### FR-05 Character Companion

| ID | Functional Requirement |
|----|------------------------|
| FR-05.1 | User dapat memilih character |
| FR-05.2 | Sistem menampilkan respon character berdasarkan journal |
| FR-05.3 | Sistem menampilkan feedback berdasarkan habit user |

### FR-06 Progress Monitoring

| ID | Functional Requirement |
|----|------------------------|
| FR-06.1 | User dapat melihat streak habit |
| FR-06.2 | User dapat melihat riwayat aktivitas |
| FR-06.3 | User dapat melihat summary progres |

---

## 🛠️ Teknologi

- **Framework**: Blazor (.NET)
- **Bahasa Pemrograman**: C#
- **Arsitektur**: Web Application
- **Database**: (disesuaikan pada implementasi)

---

## 🚀 Status Proyek

- ✅ Spesifikasi MVP selesai
- 🔄 Dalam tahap pengembangan fitur inti

---

✨ *myKisah — Build habits, write your journey, grow together.*
