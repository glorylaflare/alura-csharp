using System.ComponentModel.DataAnnotations;

namespace HoteisApi.Data.Dtos;

public class UpdateHotelDto
{
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
}