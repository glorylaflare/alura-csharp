using System.ComponentModel.DataAnnotations;

namespace HoteisApi.Data.Dtos;

public class UpdateHotelDto
{
    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [StringLength(100, ErrorMessage = "O {0} do hotel não pode exceder {1} caracteres.", MinimumLength = 3)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [StringLength(200, ErrorMessage = "O {0} do hotel não pode exceder {1} caracteres.", MinimumLength = 10)]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [StringLength(100, ErrorMessage = "A {0} do hotel não pode exceder {1} caracteres.", MinimumLength = 3)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [StringLength(100, ErrorMessage = "O {0} do hotel não pode exceder {1} caracteres.", MinimumLength = 2)]
    public string Pais { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O {0} do hotel deve estar no formato XXXXX-XXX.")]
    public string CEP { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    // Quero um regex que aceite esse tipo de número de telefone: +55 11 91234-5678 ou 11912345678
    [RegularExpression(@"^\+?\d{1,3}\s?\d{1,2}\s?\d{4,5}-?\d{4}$", ErrorMessage = "O {0} do hotel deve estar no formato válido.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [Range(1, 5, ErrorMessage = "O {0} do hotel deve estar entre {1} e {2}.")]
    public int Estrelas { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    public bool TemWifi { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    public bool TemEstacionamento { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    public bool AceitaAnimais { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    public bool TemPiscina { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    public bool TemAcademia { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    public bool TemRestaurante { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [StringLength(500, ErrorMessage = "A {0} do hotel não pode exceder {1} caracteres.", MinimumLength = 10)]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O {0} do hotel é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O {0} do hotel deve ser maior que zero.")]
    public decimal PrecoMedioDiaria { get; set; }
}