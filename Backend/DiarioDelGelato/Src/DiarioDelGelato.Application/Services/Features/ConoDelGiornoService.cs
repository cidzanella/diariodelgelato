using AutoMapper;
using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Application.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiarioDelGelato.Application.DTOs.Features.ConoDelGiornoDTOs;
using DiarioDelGelato.Application.Interfaces.Services.Features;

namespace DiarioDelGelato.Application.Services.Features
{
    public class ConoDelGiornoService : IConoDelGiornoService
    {
        private readonly IConoDelGiornoRepositoryAsync _conoDelGiornoRepository;
        private readonly IMapper _mapper;

        public ConoDelGiornoService(IConoDelGiornoRepositoryAsync conoDelGiornoRepository, IMapper mapper)
        {
            _conoDelGiornoRepository = conoDelGiornoRepository;
            _mapper = mapper;
        }
        public async Task<ConoDelGiornoResponseDto> RegisterConoDelGiornoAsync(ConoDelGiornoCreateRequestDto conoDelGiornoCreateRequest)
        {
            var conoDelGiorno = _mapper.Map<ConoDelGiorno>(conoDelGiornoCreateRequest);
            conoDelGiorno.Timestamp = new DateTime().ToUnixTimestampUtcNow();
            return _mapper.Map<ConoDelGiornoResponseDto>(await _conoDelGiornoRepository.AddAsync(conoDelGiorno));
        }

        public async Task<bool> ValidateConoDelGiornoBreakAsync(int teamMemberId)
        {
            // check if current break is on scheduled break time
            // await _teamRepository.GetBreakScheduleAsync(teamMemberId)

            return await Task.FromResult(true);
        }
    }
}
