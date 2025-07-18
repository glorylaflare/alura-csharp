using HoteisApi.Models;

namespace HoteisApi.Data.Dtos;

public class CreateQuartoDto
{
    public int Numero { get; set; }
    public TipoEnum Tipo { get; set; }
    public int Capacidade { get; set; }
    public decimal PrecoMedioDiaria { get; set; }
    public bool Disponivel { get; set; }
}