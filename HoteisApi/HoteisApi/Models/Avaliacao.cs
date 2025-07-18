using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoteisApi.Models;

public class Avaliacao
{
    [Key]
    [Required]
    public int Id { get; set; }
    public double Nota  { get; set; }
    public string Comentario { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Data { get; set; }
    
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
}