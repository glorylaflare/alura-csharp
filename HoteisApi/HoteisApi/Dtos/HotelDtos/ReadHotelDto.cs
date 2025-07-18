namespace HoteisApi.Data.Dtos;

public record ReadHotelDto(
    int Id,
    string Nome,
    string Descricao,
    string Telefone,
    int Estrelas,
    bool TemWifi,
    bool TemEstacionamento,
    bool AceitaAnimais,
    bool TemPiscina,
    bool TemAcademia,
    bool TemRestaurante,
    EnderecoDto Endereco);