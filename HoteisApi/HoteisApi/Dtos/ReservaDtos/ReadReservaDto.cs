using HoteisApi.Models;

namespace HoteisApi.Data.Dtos;

public record ReadReservaDto(
    int Id,
    DateOnly CheckIn,
    DateOnly CheckOut,
    decimal PrecoTotal,
    Hotel Hotel,
    Quarto Quarto,
    Cliente Cliente);