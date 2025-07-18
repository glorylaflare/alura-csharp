using System.ComponentModel.DataAnnotations;

namespace HoteisApi.Models;

public class Hotel
{
    [Key]
    [Required]
    public int Id { get; set; } 
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Telefone { get; set; }
    public int Estrelas { get; set; }
    public bool TemWifi { get; set; }
    public bool TemEstacionamento { get; set; }
    public bool AceitaAnimais { get; set; }
    public bool TemPiscina { get; set; }
    public bool TemAcademia { get; set; }
    public bool TemRestaurante { get; set; }
    
    public Endereco Endereco { get; set; }
    
    public ICollection<Quarto> Quartos { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
}