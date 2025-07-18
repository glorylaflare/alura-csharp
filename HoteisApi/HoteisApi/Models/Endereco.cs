using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HoteisApi.Models;

[Owned]
public class Endereco
{
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public string CEP { get; set; }
}