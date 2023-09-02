using AutoMapper;
using DiarioDelGelato.Application.DTOs;
using DiarioDelGelato.Application.Exceptions;
using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Services
{
    /// 
    /// Either use GelatoService or MediatR with commands and queries on Features/Gelatos
    /// 
    public class GelatoService : IGelatoService
    {
        private readonly IGelatoRepositoryAsync _gelatoRepository;
        private readonly IMapper _mapper;

        public GelatoService(IGelatoRepositoryAsync gelatoRepository, IMapper mapper)
        {
            _gelatoRepository = gelatoRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GelatoResponseDto>> ReadGelatosAsync()
        {
            return _mapper.Map<IReadOnlyList<GelatoResponseDto>>( await _gelatoRepository.GetAllAsync());
        }
        
        public async Task<GelatoResponseDto> ReadGelatoAsync(int id)
        {
            var gelato = await _gelatoRepository.GetByIdAsync(id);

            if (gelato == null)
                throw new NotFoundException();

             return _mapper.Map<GelatoResponseDto>(gelato);
        }

        public async Task<GelatoResponseDto> CreateGelatoAsync(GelatoCreateRequestDto gelatoCreateRequest)
        {
            if (await _gelatoRepository.GelatoExists(gelatoCreateRequest.Name))
                throw new Exception($"Duplicated gelato name. {gelatoCreateRequest.Name} already exists on database.");

            var gelato = _mapper.Map<Gelato>(gelatoCreateRequest);
            return _mapper.Map<GelatoResponseDto>(await _gelatoRepository.AddAsync(gelato));
        }

        public async Task UpdateGelatoAsync(GelatoUpdateRequestDto gelatoUpdateRequest)
        {
            if (_gelatoRepository.GetByIdAsync(gelatoUpdateRequest.Id) == null)
                throw new NotFoundException();

            var gelato = _mapper.Map<Gelato>(gelatoUpdateRequest);
            await _gelatoRepository.UpdateAsync(gelato);

        }

        public async Task DeleteGelatoAsync(int id)
        {
            var gelato = await _gelatoRepository.GetByIdAsync(id);
            if (gelato == null)
                throw new NotFoundException();
            await _gelatoRepository.DeleteAsync(gelato);
            
        }

    }
}
