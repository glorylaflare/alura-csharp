namespace HoteisApi.Data.Dtos;

public class UpdateReservaDto
{
    public DateOnly CheckOut { get; set; }
    
    public int QuartoId { get; set; }
    public int ClienteId { get; set; }
}