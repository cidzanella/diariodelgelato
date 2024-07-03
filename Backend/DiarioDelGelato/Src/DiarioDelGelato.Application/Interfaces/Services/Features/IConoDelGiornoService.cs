using DiarioDelGelato.Application.DTOs.Features.ConoDelGiornoDTOs;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Features
{
    public interface IConoDelGiornoService
    {
        //TODO:ServiceResponse
        Task<ConoDelGiornoResponseDto> RegisterConoDelGiornoAsync(ConoDelGiornoCreateRequestDto conoDelGiornoCreateRequest);
        Task<bool> ValidateConoDelGiornoBreakAsync(int teamMemberId);
    }
}
