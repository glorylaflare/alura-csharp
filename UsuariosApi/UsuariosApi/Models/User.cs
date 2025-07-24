using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models;

public class User : IdentityUser
{
    public DateOnly DateOfBirth { get; set; }

    public User() : base() { }
}