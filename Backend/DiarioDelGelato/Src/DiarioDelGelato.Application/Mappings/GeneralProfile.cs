
using AutoMapper;
using DiarioDelGelato.Application.DTOs.Features.UserDTOs;
using DiarioDelGelato.Application.DTOs.Features.ConoDelGiornoDTOs;
using DiarioDelGelato.Application.DTOs.Features.GelatoDTOs;
using DiarioDelGelato.Application.DTOs.Features.TeamDTOs;
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

            CreateMap<ConoDelGiornoCreateRequestDto, ConoDelGiorno>();
            CreateMap<ConoDelGiorno,  ConoDelGiornoResponseDto>();

            CreateMap<UserCreateRequestDto, User>();
            CreateMap<UserUpdateRequestDto, User>();
            CreateMap<User, UserResponseDto>();
            CreateMap<User, UserAuthenticationDataReponseDto>();

            CreateMap<TeamMemberCreateRequestDto, TeamMember>();
            CreateMap<TeamMemberUpdateRequestDto, TeamMember>();
            CreateMap<TeamMember, TeamMemberResponseDto>();
        }
    }
}
