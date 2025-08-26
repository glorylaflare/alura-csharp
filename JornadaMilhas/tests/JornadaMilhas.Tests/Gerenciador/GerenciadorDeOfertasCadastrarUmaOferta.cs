using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Tests;

public class GerenciadorDeOfertasCadastrarUmaOferta
{
    [Fact]
    public void RetornarSucessoQuandoAdicionarUmaOfertaValida()
    {
        // Arrange
        var ofertas = new List<OfertaViagem>();

        var gerenciador = new GerenciadorDeOfertas(ofertas);
        var rota = new Rota("GRU", "REC");
        var periodo = new Periodo(DateTime.Now.AddDays(10), DateTime.Now.AddDays(15));
        var ofertaValida = new OfertaViagem(rota, periodo, 299.99);
        // Act
        var resultado = gerenciador.AdicionarOfertaNaLista(ofertaValida);
        // Assert
        Assert.True(resultado);
        Assert.Contains(ofertaValida, ofertas);
    }

    [Fact]
    public void RetornarFalhaQuandoAdicionarUmaOfertaNula()
    {
        // Arrange
        var ofertas = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(ofertas);
        OfertaViagem ofertaInvalida = null;
        // Act
        var resultado = gerenciador.AdicionarOfertaNaLista(ofertaInvalida);
        // Assert
        Assert.False(resultado);
        Assert.Empty(ofertas);
    }
}
