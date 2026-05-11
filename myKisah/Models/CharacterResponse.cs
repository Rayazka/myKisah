using System;
namespace myKisah.Models
{
    // Ini adalah kelas untuk menyimpan data karakter yang akan ditampilkan di halaman detail karakter
    public class CharacterResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}