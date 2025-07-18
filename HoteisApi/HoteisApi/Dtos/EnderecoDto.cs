namespace HoteisApi.Data.Dtos;

public record EnderecoDto (
    string Logradouro,
    string Cidade,
    string Estado,
    string Pais,
    string CEP);