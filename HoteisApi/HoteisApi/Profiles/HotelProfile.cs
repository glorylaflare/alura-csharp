using HoteisApi.Data.Dtos;
using HoteisApi.Models;
using AutoMapper;

namespace HoteisApi.Profiles;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<CreateHotelDto, Hotel>();
        CreateMap<UpdateHotelDto, Hotel>();
        CreateMap<Hotel, UpdateHotelDto>();
        CreateMap<Hotel, ReadHotelDto>();
    }
}