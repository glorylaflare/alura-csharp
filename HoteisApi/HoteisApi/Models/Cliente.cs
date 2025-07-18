using System.ComponentModel.DataAnnotations;

namespace HoteisApi.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Documento { get; set; }
    
    public ICollection<Reserva> Reservas { get; set; }
}