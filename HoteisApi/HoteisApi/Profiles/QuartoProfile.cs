using AutoMapper;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;

namespace HoteisApi.Profiles;

public class QuartoProfile : Profile
{
    public QuartoProfile()
    {
        CreateMap<CreateQuartoDto, Quarto>();
        CreateMap<Quarto, CreateQuartoDto>();
        
        CreateMap<UpdateQuartoDto, Quarto>();
        CreateMap<Quarto, UpdateQuartoDto>();
        
        CreateMap<Quarto, ReadQuartoDto>();
    }
}