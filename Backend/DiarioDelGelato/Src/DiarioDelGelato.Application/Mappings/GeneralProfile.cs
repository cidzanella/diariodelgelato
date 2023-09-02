
using AutoMapper;
using DiarioDelGelato.Application.DTOs;
using DiarioDelGelato.Domain.Entities;

namespace DiarioDelGelato.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<GelatoCreateRequestDto, Gelato>();
            CreateMap<Gelato, GelatoResponseDto>();
            CreateMap<GelatoUpdateRequestDto, Gelato>();
        }
    }
}
