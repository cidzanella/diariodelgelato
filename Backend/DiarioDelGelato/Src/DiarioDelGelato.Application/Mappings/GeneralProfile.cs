using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
