using HoteisApi.Models;

namespace HoteisApi.Data.Dtos;

public record ReadClienteDto(
    int Id,
    int Nome,
    string Email,
    string Telefone,
    string Documento,
    ICollection<Reserva> Reservas);