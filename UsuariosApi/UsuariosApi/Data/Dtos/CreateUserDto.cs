using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public DateOnly DateOfBirth { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}