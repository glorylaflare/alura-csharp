using HoteisApi.Models;

namespace HoteisApi.Data.Dtos;

public record ReadAvaliacoesDto(
    int Id,
    double Nota,
    string Comentario,
    DateTime Data);