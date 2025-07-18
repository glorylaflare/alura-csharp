using System.ComponentModel.DataAnnotations;

namespace HoteisApi.Models;

public class Quarto
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int Numero { get; set; }
    public TipoEnum Tipo { get; set; }
    public int Capacidade { get; set; }
    public decimal PrecoMedioDiaria { get; set; }
    public bool Disponivel { get; set; }
    
    public int HotelId { get; set; } 
    public Hotel Hotel { get; set; }
}

public enum TipoEnum
{
    Standard,
    Luxo,
    Suíte
}