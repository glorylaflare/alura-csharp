using AutoMapper;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;

namespace HoteisApi.Profiles;

public class AvaliacaoProfile : Profile
{
    public AvaliacaoProfile()
    {
        CreateMap<CreateAvaliacaoDto, Avaliacao>();
        CreateMap<Avaliacao, CreateAvaliacaoDto>();
        
        CreateMap<Avaliacao, ReadAvaliacoesDto>();
    }
}