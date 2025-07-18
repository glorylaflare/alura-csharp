using HoteisApi.Models;

namespace HoteisApi.Data.Dtos;

public record ReadQuartoDto(
    int Id,
    int Numero,
    TipoEnum Tipo,
    int Capacidade,
    decimal PrecoMedioDiaria,
    bool Disponivel,
    Hotel Hotel);