using System.ComponentModel.DataAnnotations;

namespace HoteisApi.Models;

public class Reserva
{
    [Key]
    [Required]
    public int Id { get; set; }
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    public decimal PrecoTotal { get; set; }
    
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    
    public int QuartoId { get; set; }
    public Quarto Quarto { get; set; }
    
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}