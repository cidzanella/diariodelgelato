
using AutoMapper;
using DiarioDelGelato.Application.DTOs;
using DiarioDelGelato.Domain.Entities;

namespace DiarioDelGelato.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<GelatoCreateRequest, Gelato>();
            CreateMap<Gelato, GelatoResponse>();
            CreateMap<GelatoUpdateRequest, Gelato>();
        }
    }
}
