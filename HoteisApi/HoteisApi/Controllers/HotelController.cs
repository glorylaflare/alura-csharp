using AutoMapper;
using HoteisApi.Data;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HoteisApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")] // Route to access the controller
public class HotelController : ControllerBase
{
    /*
    private static List<Hotel> hoteis = new List<Hotel>(); // Static list to hold hotels
    private static int idCounter = 1; // Static counter to generate unique IDs
    */
    
    private readonly HotelContext _context; // Database context for accessing hotels
    private readonly IMapper _mapper; // AutoMapper for mapping DTOs to models

    public HotelController(HotelContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um novo hotel ao banco de dados.
    /// </summary>
    /// <param name="hotelDto">Objeto DTO contendo os dados do hotel a ser criado.</param>
    /// <returns>
    /// Retorna um status 201 Created com os dados do hotel criado e o local do recurso.
    /// </returns>
    [HttpPost] // Route to add a hotel
    public ActionResult AdicionaHotel([FromBody] CreateHotelDto hotelDto)
    {
        var hotel = _mapper.Map<Hotel>(hotelDto); // Map the DTO to the Hotel model
        _context.Hoteis.Add(hotel); // Add the hotel to the database context
        _context.SaveChanges();
        Console.WriteLine($"Hotel {hotel.Nome} adicionado com sucesso!");
        return CreatedAtAction(nameof(RecuperaHotelPorId), 
            new { id = hotel.Id }, hotelDto
        ); // Returns a 201 Created response with the location of the new hotel
    }

    /// <summary>
    /// Recupera uma lista paginada de hotéis do banco de dados.
    /// </summary>
    /// <param name="skip">Número de hotéis a serem ignorados (para paginação).</param>
    /// <param name="take">Número de hotéis a serem retornados.</param>
    /// <returns>Retorna uma lista paginada de hotéis no formato DTO.</returns>
    [HttpGet] // Route to retrieve the list of hotels
    public ActionResult RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        // Returns the list of hotels
        var hoteis = _context.Hoteis
            .Skip(skip) // Skips the specified number of hotels
            .Take(take) // Takes the specified number of hotels
            .ToList(); // Converts the result to a list
        
        var hoteisDto = _mapper.Map<List<ReadHotelDto>>(hoteis); // Maps the list of hotels to a list of DTOs
        return Ok(hoteisDto); // Returns a paginated list of hotels (5 per page)
    }
    
    /// <summary>
    /// Recupera um hotel específico pelo seu ID.
    /// </summary>
    /// <param name="id">ID do hotel a ser recuperado.</param>
    /// <returns>
    /// Retorna um objeto <see cref="ReadHotelDto"/> com os dados do hotel, ou 404 NotFound se não encontrado.
    /// </returns>
    [HttpGet("{id}")] // Route to retrieve a specific hotel by ID
    public ActionResult RecuperaHotelPorId(int id)
    {
        // Searches for the hotel by ID
        var hotel = _context.Hoteis.FirstOrDefault(h => h.Id == id);
        
        if (hotel == null)
        {
            return NotFound(); // Returns 404 if the hotel is not found
        }
        
        var hotelDto = _mapper.Map<ReadHotelDto>(hotel); // Maps the hotel model to a DTO
        return Ok(hotelDto); // Returns the hotel if found
    }
    
    /// <summary>
    /// Atualiza completamente um hotel existente pelo seu ID.
    /// </summary>
    /// <param name="id">ID do hotel a ser atualizado.</param>
    /// <param name="hotelDto">Objeto DTO contendo os novos dados do hotel.</param>
    /// <returns>
    /// Retorna 204 No Content se a atualização for bem-sucedida ou 404 NotFound se o hotel não for encontrado.
    /// </returns>
    [HttpPut("{id}")] // Route to update a hotel by ID
    public ActionResult AtualizaHotel(int id, [FromBody] UpdateHotelDto hotelDto)
    {
        var hotel = _context.Hoteis.FirstOrDefault(h => h.Id == id);
        
        if (hotel == null)
        {
            return NotFound(); // Returns 404 if the hotel is not found
        }
        
        _mapper.Map(hotelDto, hotel); // Maps the updated DTO to the existing hotel model
        _context.SaveChanges(); // Saves the changes to the database
        return NoContent(); // Returns 204 No Content to indicate success
    }
    
    /// <summary>
    /// Atualiza parcialmente um hotel existente pelo seu ID usando um documento JSON Patch.
    /// </summary>
    /// <param name="id">ID do hotel a ser atualizado.</param>
    /// <param name="patch">Documento JSON Patch contendo as operações de atualização parciais.</param>
    /// <returns>
    /// Retorna 204 No Content se a atualização for bem-sucedida, 400 Bad Request se o modelo for inválido ou 404 NotFound se o hotel não for encontrado.
    /// </returns>
    [HttpPatch("{id}")] // Route to update a hotel by ID
    public ActionResult AtualizaHotelParcial(int id, JsonPatchDocument<UpdateHotelDto> patch)
    {
        var hotel = _context.Hoteis.FirstOrDefault(h => h.Id == id);
        
        if (hotel == null)
        {
            return NotFound(); // Returns 404 if the hotel is not found
        }
        
        var hotelParaAtualizar = _mapper.Map<UpdateHotelDto>(hotel); // Maps the existing hotel to a DTO for patching
        patch.ApplyTo(hotelParaAtualizar, ModelState); // Applies the patch document to the DTO
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Returns 400 Bad Request if the model state is invalid
        }
        
        _mapper.Map(hotelParaAtualizar, hotel); // Maps the updated DTO to the existing hotel model
        _context.SaveChanges(); // Saves the changes to the database
        return NoContent(); // Returns 204 No Content to indicate success
    }
    
    /// <summary>
    /// Remove um hotel existente pelo seu ID.
    /// </summary>
    /// <param name="id">ID do hotel a ser removido.</param>
    /// <returns>
    /// Retorna 204 No Content se a exclusão for bem-sucedida ou 404 NotFound se o hotel não for encontrado.
    /// </returns>
    [HttpDelete("{id}")] // Route to delete a hotel by ID
    public ActionResult DeletaHotel(int id)
    {
        var hotel = _context.Hoteis.FirstOrDefault(h => h.Id == id);
        
        if (hotel == null)
        {
            return NotFound(); // Returns 404 if the hotel is not found
        }
        
        _context.Hoteis.Remove(hotel); // Removes the hotel from the database context
        _context.SaveChanges(); // Saves the changes to the database
        return NoContent(); // Returns 204 No Content to indicate success
    }
}