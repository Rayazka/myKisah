using myKisah.Interfaces;
using myKisah.Models;
using myKisah.Utils;

namespace myKisah.Repositories;

// ═══════════════════════════════════════════════════════════
// KELAS: JsonUserRepository
// DOMAIN: User Management
// TEKNIK: Generics (mengimplementasikan IRepository<User>)
// PENANGGUNG JAWAB: Farel Ilham
// ═══════════════════════════════════════════════════════════

// PENJELASAN
// Repository untuk akses data User di users.json.
// Mengimplementasikan IUserRepository (yang extends IRepository<User>).

public class JsonUserRepository : IUserRepository
{
    private readonly JsonStorageHelper _storage;
    private readonly FilePathConfig _filePath;

    public JsonUserRepository(JsonStorageHelper storage, FilePathConfig filePath)
    {
        _storage = storage;
        _filePath = filePath;
    }

    // ═══ IRepository<User> ═══

    public IEnumerable<User> GetAll()
    {
        return _storage.ReadJson<User>(_filePath.UsersFile);
    }

    public User? GetById(string id)
    {
        return GetAll().FirstOrDefault(u => u.Id == id);
    }

    public void Add(User entity)
    {
        var users = GetAll().ToList();
        entity.Id = Guid.NewGuid().ToString();
        entity.CreatedAt = DateTime.UtcNow;
        users.Add(entity);
        _storage.WriteJson(_filePath.UsersFile, users);
    }

    public void Update(User entity)
    {
        var users = GetAll().ToList();
        var index = users.FindIndex(u => u.Id == entity.Id);

        if (index == -1)
            throw new KeyNotFoundException($"User dengan Id '{entity.Id}' tidak ditemukan.");
        users[index] = entity;
        _storage.WriteJson(_filePath.UsersFile, users);
    }

    public void Delete(string id)
    {
        var users = GetAll().ToList();
        users.RemoveAll(u => u.Id == id);
        _storage.WriteJson(_filePath.UsersFile, users);
    }

    // ═══ IUserRepository (spesifik) ═══

    public User? GetByUsername(string username)
    {
        return GetAll().FirstOrDefault(
            u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        );
    }

    public bool UsernameExists(string username)
    {
        return GetAll().Any(
            u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        );
    }
}
