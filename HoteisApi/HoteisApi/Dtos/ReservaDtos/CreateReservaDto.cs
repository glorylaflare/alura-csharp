namespace HoteisApi.Data.Dtos;

public class CreateReservaDto
{
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    
    public int HotelId { get; set; }
    public int QuartoId { get; set; }
    public int ClienteId { get; set; }
}