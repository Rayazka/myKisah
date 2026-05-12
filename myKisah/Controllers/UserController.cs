using Microsoft.AspNetCore.Mvc;
using myKisah.Interfaces;

namespace myKisah.Controllers;

// ═══════════════════════════════════════════════════════════
// KELAS: UserController
// DOMAIN: User Management
// TEKNIK: API Development
// PENANGGUNG JAWAB: Farel Ilham
// ═══════════════════════════════════════════════════════════
//
// PENJELASAN
// HTTP endpoint handler untuk User management.
// Menerima HTTP request, memanggil UserService, mengembalikan HTTP response.

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    // GET /api/user
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _service.GetAllUsers();
        return Ok(users);
    }

    // POST /api/user
    [HttpPost]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var user = _service.RegisterUser(request.Username);
        return Ok(user);
    }

    // PUT /api/user/{id}
    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] UpdateUserRequest request)
    {
        var user = _service.UpdateUser(id, request.Username);
        return Ok(user);
    }

    // DELETE /api/user/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _service.DeleteUser(id);
        return NoContent();
    }
}

// Request DTO — class sederhana untuk menerima JSON body
public class RegisterRequest
{
    public string Username { get; set; } = string.Empty;
}

public class UpdateUserRequest
{
    public string Username { get; set; } = string.Empty;
}
