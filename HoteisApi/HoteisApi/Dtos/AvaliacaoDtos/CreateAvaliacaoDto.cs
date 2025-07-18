using System.ComponentModel.DataAnnotations.Schema;

namespace HoteisApi.Data.Dtos;

public class CreateAvaliacaoDto
{
    public double Nota  { get; set; }
    public string Comentario { get; set; }
    public int HotelId { get; set; }
}