using Bogus;
using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Tests;

public class GerenciadorDeOfertasRecuperaMaiorDesconto
{
    [Fact]
    public void RetornaOfertaNulaQuandoListaEstaVazia()
    {
        //Arrange
        var lista = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(lista);
        Func<OfertaViagem, bool> filtro = oferta => oferta.Rota.Destino.Equals("GRU");
        //Act
        var oferta = gerenciador.RecuperaMaiorDesconto(filtro);
        //Assert
        Assert.Null(oferta);
    }

    [Fact]
    public void RetornaOfertaEspecificaQuandoDestinoSaoPauloEDesconto40()
    {
        //Arrange
        var fakerPeriodo = new Faker<Periodo>()
            .CustomInstantiator(f => {
                var dataInicial = f.Date.Soon();
                return new Periodo(dataInicial, dataInicial.AddDays(30));
        });

        var rota = new Rota("REC", "GRU");

        var fakerOferta = new Faker<OfertaViagem>()
            .CustomInstantiator(f => new OfertaViagem(
                rota,
                fakerPeriodo.Generate(),
                f.Random.Double(1000, 3000)
            ))
            .RuleFor(o => o.Desconto, f => 40)
            .RuleFor(o => o.Ativa, f => true);

        var ofertaEscolhida = new OfertaViagem(
                rota,
                fakerPeriodo.Generate(),
                80.00
            )
        { Desconto = 40, Ativa = true };

        var ofertaInativa = new OfertaViagem(
                rota,
                fakerPeriodo.Generate(),
                70.00
            )
        { Desconto = 40, Ativa = false };

        var lista = fakerOferta.Generate(200);
        lista.Add(ofertaEscolhida);
        lista.Add(ofertaInativa);

        var gerenciador = new GerenciadorDeOfertas(lista);
        Func<OfertaViagem, bool> filtro = oferta => oferta.Rota.Destino.Equals("GRU");
        var precoEsperado = 40.00;

        //Act
        var oferta = gerenciador.RecuperaMaiorDesconto(filtro);
        
        //Assert
        Assert.NotNull(oferta);
        Assert.Equal(precoEsperado, oferta.Preco, 0.001);
    }
}
