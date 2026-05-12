using myKisah.Interfaces;
using myKisah.Models;
using myKisah.Utils;

namespace myKisah.Services;

// ═══════════════════════════════════════════════════════════
// KELAS: UserService
// DOMAIN: User Management
// TEKNIK: Generics + API (digunakan oleh UserController)
// PENANGGUNG JAWAB: Farel Ilham
// ═══════════════════════════════════════════════════════════

// PENJELASAN
// Business logic untuk User management.
// Extends ServiceBase (shared validation + logging).
// Implements IUserService.

public class UserService : ServiceBase, IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    protected override string ServiceName => "UserService";

    public User RegisterUser(string username)
    {
        try
        {
            Validator.ValidateNotEmpty(username, "Username");

            if (_repository.UsernameExists(username))
            {
                throw new ArgumentException(
                    $"Username '{username}' sudah terdaftar"
                );
            }

            var user = new User
            {
                Username = username
            };

            _repository.Add(user);

            return user;
        }
        catch (Exception ex)
        {
            LogError("RegisterUser gagal", ex);
            throw;
        }
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _repository.GetAll();
    }

    public User? UpdateUser(string id, string username)
    {
        try
        {
            Validator.ValidateNotEmpty(username, "Username");

            var user = _repository.GetById(id);

            Validator.ValidateExists(user, $"User dengan Id '{id}'");

            if (_repository.UsernameExists(username) &&
                !user!.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    $"Username '{username}' sudah terdaftar"
                );
            }

            user.Username = username;

            _repository.Update(user);

            return user;
        }
        catch (Exception ex)
        {
            LogError("UpdateUser gagal", ex);
            throw;
        }
    }

    public bool DeleteUser(string id)
    {
        try
        {
            var user = _repository.GetById(id);

            Validator.ValidateExists(user, $"User dengan Id '{id}'");

            _repository.Delete(id);

            return true;
        }
        catch (Exception ex)
        {
            LogError("DeleteUser gagal", ex);
            throw;
        }
    }
}
