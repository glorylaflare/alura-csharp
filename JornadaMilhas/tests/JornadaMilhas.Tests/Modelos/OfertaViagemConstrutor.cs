using JornadaMilhasV1.Modelos;
using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.Tests.Modelos;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("GRU", "FOR", "2025-07-08", "2025-07-20", 3450.00, true)]
    [InlineData("GRU", "FOR", "2025-07-20", "2025-07-08", 3450.00, false)] // Data de início maior que data de fim
    [InlineData("GRU", "FOR", "2025-07-08", "2025-07-20", -3450.00, false)] // Preço negativo
    [InlineData("GRU", "FOR", "2025-07-08", "2025-07-20", 0.00, false)] // Preço zero
    public void RetornaOfertaValidaQuandoDadosValidos(string origem, string destino, string dataInicio, string dataFim, double preco, bool validacao)
    {
        //Arrange
        var rota = new Rota(origem, destino);
        var periodo = new Periodo(
            DateTime.Parse(dataInicio), 
            DateTime.Parse(dataFim));

        //Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        //Assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidoQuandoRotaForNula()
    {
        //Arrange
        Rota rota = null;
        var periodo = new Periodo(
            new DateTime(2025, 7, 8), 
            new DateTime(2025, 7, 20));
        var preco = 3450.00;

        //Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        //Assert
        Assert.False(oferta.EhValido);
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
    }

    [Fact]
    public void RetornaMensagemDeErroQuandoDataInicioForMaiorQueDataFinal()
    {
        //Arrange
        var rota = new Rota("GRU", "FOR");
        var periodo = new Periodo(
            new DateTime(2025, 7, 20), 
            new DateTime(2025, 7, 8));
        var preco = 3450.00;

        //Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        //Assert
        Assert.False(oferta.EhValido);
        Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
    }

    [Fact]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoForMenorQueZero()
    {
        //Arrange
        var rota = new Rota("GRU", "FOR");
        var periodo = new Periodo(
            new DateTime(2025, 7, 8), 
            new DateTime(2025, 7, 20));
        var preco = -3450.00;

        //Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        //Assert
        Assert.False(oferta.EhValido);
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }
}
