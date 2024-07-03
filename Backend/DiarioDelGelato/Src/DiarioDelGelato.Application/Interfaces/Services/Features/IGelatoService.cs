using DiarioDelGelato.Application.DTOs.Features.GelatoDTOs;
using DiarioDelGelato.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Features
{
    // implements CRUD services using repository
    public interface IGelatoService
    {
        //TODO:ServiceResponse
        Task<IReadOnlyList<GelatoResponseDto>> ReadGelatosAsync();
        Task<GelatoResponseDto> ReadGelatoAsync(int id);
        Task<GelatoResponseDto> CreateGelatoAsync(GelatoCreateRequestDto gelatoCreateRequest);
        Task UpdateGelatoAsync(GelatoUpdateRequestDto gelatoUpdateRequest);
        Task DeleteGelatoAsync(int id);
    }
}
