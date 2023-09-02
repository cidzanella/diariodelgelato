using DiarioDelGelato.Application.DTOs;
using DiarioDelGelato.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services
{
    // implements CRUD services using repository
    public interface IGelatoService
    {
        Task<IReadOnlyList<GelatoResponseDto>> ReadGelatosAsync();
        Task<GelatoResponseDto> ReadGelatoAsync(int id);
        Task<GelatoResponseDto> CreateGelatoAsync(GelatoCreateRequestDto gelatoCreateRequest);
        Task UpdateGelatoAsync(GelatoUpdateRequestDto gelatoUpdateRequest);
        Task DeleteGelatoAsync(int id);

    }
}
