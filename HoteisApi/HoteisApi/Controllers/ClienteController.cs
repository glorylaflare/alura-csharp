using AutoMapper;
using HoteisApi.Data;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoteisApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")] // Route to access the controller
public class ClienteController : ControllerBase
{
    private readonly HotelContext _hotelContext;
    private readonly IMapper _mapper;

    public ClienteController(HotelContext hotelContext, IMapper mapper)
    {
        _hotelContext = hotelContext;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult AdicionarCliente([FromBody] CreateClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        _hotelContext.Clientes.Add(cliente);
        _hotelContext.SaveChanges();
        Console.WriteLine($"Cliente {cliente.Nome} adicionado com sucesso!");
        return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, clienteDto);
    }

    [HttpGet]

    [HttpGet("{id}")]
    /*
    public ActionResult<Cliente> RecuperaClientePorId(int id)
    {
        var cliente 
    }
    */
    [HttpPut]

    [HttpDelete]
}