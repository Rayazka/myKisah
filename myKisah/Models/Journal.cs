using System;
namespace myKisah.Models
{
    // Ini adalah kelas untuk menyimpan data jurnal yang akan ditampilkan di halaman daftar jurnal
    public class Journal
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Mood { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}