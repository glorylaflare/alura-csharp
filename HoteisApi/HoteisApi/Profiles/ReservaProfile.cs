using AutoMapper;
using HoteisApi.Data.Dtos;
using HoteisApi.Models;

namespace HoteisApi.Profiles;

public class ReservaProfile : Profile
{
    public ReservaProfile()
    {
        CreateMap<CreateReservaDto, Reserva>();
        CreateMap<Reserva, CreateReservaDto>();
        
        CreateMap<UpdateReservaDto, Reserva>();
        CreateMap<Reserva, UpdateReservaDto>();
        
        CreateMap<Reserva, ReadReservaDto>();
    }
}