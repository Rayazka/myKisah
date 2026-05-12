using System.Text.Json;
using System.Text.Json.Serialization;

namespace myKisah.Utils;

// ═══════════════════════════════════════════════════════════
// KELAS: JsonStorageHelper
// DOMAIN: Storage Layer (dipakai semua Repository)
// TEKNIK: Code Reuse / Library + Generics
// PENANGGUNG JAWAB: Rafly Putra
// ═══════════════════════════════════════════════════════════
//
// 📘 APA INI?
// Helper generic untuk baca/tulis data ke file JSON.
// Dipakai oleh SEMUA repository (User, Journal, Character, Response).
// Ini adalah SATU-SATUNYA tempat kode baca/tulis JSON — tidak boleh
// ada duplikasi kode JSON di tempat lain.
//
// 🧠 KENAPA CODE REUSE?
// Tanpa helper ini, setiap repository akan punya kode baca/tulis JSON
// yang SAMA PERSIS — 4x duplikasi. Kalau format berubah, harus ubah 4 file.
// Dengan helper ini: 1 file, 1 tempat perubahan.
//
// 🧠 KENAPA GENERICS (<T>)?
// ReadJson<User>() dan ReadJson<Journal>() pakai method yang SAMA.
// Tanpa generics: ReadUsers(), ReadJournals(), ReadCharacters()...
// Dengan generics: ReadJson<T>() — hanya 1 method.
//
// Design by Contract:
// - filename tidak boleh null (precondition)
// - data tidak boleh null saat write (precondition)
// - File yang tidak ada di-auto-create dengan array kosong "[]"
// - Return List<T> kosong (bukan null) jika file baru dibuat
//
// 📋 TODO:
// [ ] 1. Constructor: terima FilePathConfig via DI
//        - Simpan Directory.GetCurrentDirectory() + filePathConfig sebagai base path
//        - Atau bisa pakai cara lain untuk resolve full path
//
// [ ] 2. Implement ReadJson<T>(string filename):
//        a. Gabungkan _basePath + filename jadi fullPath
//        b. Cek File.Exists(fullPath):
//           - Jika TIDAK: File.WriteAllText(fullPath, "[]"), return new List<T>()
//           - Jika ADA: baca File.ReadAllText → JsonSerializer.Deserialize<List<T>> → return
//        c. Wrap dengan try-catch: jika JSON corrupt, return empty list
//
// [ ] 3. Implement WriteJson<T>(string filename, List<T> data):
//        a. Gabungkan _basePath + filename jadi fullPath
//        b. Pastikan Directory.CreateDirectory(parent directory) — jaga-jaga
//        c. JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true })
//        d. File.WriteAllText(fullPath, json)
//
// Tips:
// - Pakai System.Text.Json (bawaan .NET, tidak perlu NuGet tambahan)
// - JsonSerializerOptions dengan WriteIndented = true biar JSON rapi
// - Jangan lupa using System.Text.Json di atas
//
// Referensi: Task_myKisah.md baris 128-138

// public class JsonStorageHelper
// {  
// }
public class JsonStorageHelper
{
    private readonly string _basePath;
    private readonly IHostEnvironment _env;

    public JsonStorageHelper(FilePathConfig filePathConfig, IHostEnvironment env)
    {
        _env = env;
        _basePath = env.ContentRootPath; 
    }

    public List<T> ReadJson<T>(string filename)
{
    // 1. Gabung base path + nama file
    var fullPath = Path.Combine(_basePath, filename);
    Console.WriteLine($"[DEBUG] FullPath: {fullPath}");
    // 2. Kalau file belum ada → auto-create dengan array kosong
    if (!File.Exists(fullPath))
    {
        Console.WriteLine($"[DEBUG] File tidak ditemukan, membuat baru...");
        var directory = Path.GetDirectoryName(fullPath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        File.WriteAllText(fullPath, "[]");
        return new List<T>();
    }
    // 3. Baca isi file
    var json = File.ReadAllText(fullPath);
    Console.WriteLine($"[DEBUG] JSON dibaca: {(json.Length > 100 ? json.Substring(0, 100) + "..." : json)}");
    // 4. Kalau kosong → return empty
    if (string.IsNullOrWhiteSpace(json))
        return new List<T>();
    // 5. Deserialize — PAKAI JsonStringEnumConverter supaya "Happy" → MoodType.Happy
    var options = new JsonSerializerOptions
    {
        Converters = { new JsonStringEnumConverter() },
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    var result = JsonSerializer.Deserialize<List<T>>(json, options);
    Console.WriteLine($"[DEBUG] Deserialized count: {result?.Count ?? 0}");
    return result ?? new List<T>();
}
    public void WriteJson<T>(string filename, List<T> data)
    {
        var fullPath = Path.Combine(_basePath, filename);
        Console.WriteLine($"[DEBUG] WriteJson FullPath: {fullPath}");
        Console.WriteLine($"[DEBUG] WriteJson Count: {data.Count}");

        // Pastikan folder tujuan ada
        var directory = Path.GetDirectoryName(fullPath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        // Serialize dengan options SAMA seperti ReadJson
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };

        var json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(fullPath, json);
        Console.WriteLine($"[DEBUG] WriteJson berhasil: {data.Count} item tersimpan");
    }
}
