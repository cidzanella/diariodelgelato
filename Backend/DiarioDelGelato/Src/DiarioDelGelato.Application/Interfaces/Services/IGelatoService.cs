using DiarioDelGelato.Application.DTOs;
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
        Task<IReadOnlyList<GelatoResponse>> ReadGelatosAsync();
        Task<GelatoResponse> ReadGelatoAsync(int id);
        Task<GelatoResponse> CreateGelatoAsync(GelatoCreateRequest gelatoCreateRequest);
        Task<GelatoResponse> UpdateGelatoAsync(GelatoUpdateRequest gelatoUpdateRequest);
        Task<GelatoResponse> DeleteGelatoAsync(int id);

    }
}
