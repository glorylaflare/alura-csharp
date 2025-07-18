using AutoMapper;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;

namespace HoteisApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, CreateClienteDto>();
        
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
        
        CreateMap<Cliente, ReadClienteDto>();
    }
}