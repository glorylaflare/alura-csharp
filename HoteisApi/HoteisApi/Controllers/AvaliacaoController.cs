using AutoMapper;
using HoteisApi.Data;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoteisApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")] // Route to access the controller
public class AvaliacaoController : ControllerBase
{
    private readonly HotelContext _context;
    private readonly IMapper _mapper;

    public AvaliacaoController(HotelContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Recupera uma lista paginada de avaliações.
    /// </summary>
    /// <param name="skip">Número de avaliações a serem ignoradas (para paginação).</param>
    /// <param name="take">Número máximo de avaliações a serem retornadas.</param>
    /// <returns>Retorna uma lista de avaliações no formato ReadAvaliacoesDto.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Avaliacao>> RecuperaAvaliacao([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var avaliacoes =  _context.Avaliacoes
            .Skip(skip)
            .Take(take)
            .ToList();
        var avaliacoesDto = _mapper.Map<List<ReadAvaliacoesDto>>(avaliacoes);
        return Ok(avaliacoesDto);
    }
    
    /// <summary>
    /// Recupera uma avaliação pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador da avaliação a ser recuperada.</param>
    /// <returns>Retorna os dados da avaliação encontrada ou NotFound se não existir.</returns>
    [HttpGet("{id}")]
    public ActionResult<ReadAvaliacoesDto> RecuperaAvaliacaoPorId(int id)
    {
        var avaliacao = _context.Avaliacoes.FirstOrDefault(a => a.Id == id);
        if  (avaliacao == null) NotFound();
        var avaliacaoDto = _mapper.Map<ReadAvaliacoesDto>(avaliacao);
        return Ok(avaliacaoDto);
    }

    /// <summary>
    /// Cria uma nova avaliação.
    /// </summary>
    /// <param name="avaliacaoDto">Objeto contendo os dados da avaliação a ser criada.</param>
    /// <returns>Retorna o status 201 Created com a localização da nova avaliação criada.</returns>
    [HttpPost]
    public ActionResult CriaUmAvaliacao([FromBody] CreateAvaliacaoDto avaliacaoDto)
    {
        var avaliacao =  _mapper.Map<Avaliacao>(avaliacaoDto);
        _context.Avaliacoes.Add(avaliacao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAvaliacaoPorId), new { id = avaliacao.Id }, avaliacaoDto);
    }

    /// <summary>
    /// Remove uma avaliação pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador da avaliação a ser removida.</param>
    /// <returns>NoContent se removido com sucesso, ou NotFound se não existir.</returns>
    [HttpDelete]
    public ActionResult RemoverAvaliacao(int id)
    {
        var avaliacao = _context.Avaliacoes.FirstOrDefault(a => a.Id == id);
        if (avaliacao == null) NotFound();
        _context.Avaliacoes.Remove(avaliacao);
        _context.SaveChanges();
        return NoContent();
    }
}