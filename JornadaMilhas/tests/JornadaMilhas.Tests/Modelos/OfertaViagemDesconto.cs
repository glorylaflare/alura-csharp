using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Tests;

public class OfertaViagemDesconto
{
    [Fact]
    public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
    {
        //Arrange
        Rota rota = new Rota("GRU", "REC");
        var periodo = new Periodo(
            new DateTime(2025, 7, 8),
            new DateTime(2025, 7, 20));
        var precoOriginal = 2150.00;
        var desconto = 150.00;
        var precoComDesconto = precoOriginal - desconto;
        var oferta = new OfertaViagem(rota, periodo, precoOriginal);

        //Act
        oferta.Desconto = desconto;

        //Assert
        Assert.Equal(precoComDesconto, oferta.Preco);
    }

    [Theory]
    [InlineData(120.00, 30)]
    [InlineData(100.00, 30)]
    public void RetornaDescontoMaximoQuandoValorDescontoMaiorOuIgualAoPreco(double desconto, double precoComDesconto)
    {
        //Arrange
        Rota rota = new Rota("GRU", "REC");
        var periodo = new Periodo(
            new DateTime(2025, 7, 8),
            new DateTime(2025, 7, 20));
        var precoOriginal = 100.00;
        var oferta = new OfertaViagem(rota, periodo, precoOriginal);

        //Act
        oferta.Desconto = desconto;

        //Assert
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }

    [Fact]
    public void RetornaPrecoOriginalQuandoDescontoNegativo()
    {
        //Arrange
        Rota rota = new Rota("GRU", "REC");
        var periodo = new Periodo(
            new DateTime(2025, 7, 8),
            new DateTime(2025, 7, 20));
        var precoOriginal = 2150.00;
        var desconto = -800.00;
        var precoComDesconto = precoOriginal;
        var oferta = new OfertaViagem(rota, periodo, precoOriginal);

        //Act
        oferta.Desconto = desconto;

        //Assert
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }


}
