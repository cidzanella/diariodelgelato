using AutoMapper;
using DiarioDelGelato.Application.DTOs;
using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Services
{
    public class GelatoService : IGelatoService
    {
        private readonly IGelatoRepositoryAsync _gelatoRepository;
        private readonly IMapper _mapper;

        public GelatoService(IGelatoRepositoryAsync gelatoRepository, IMapper mapper)
        {
            _gelatoRepository = gelatoRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GelatoResponse>> ReadGelatosAsync()
        {
            return _mapper.Map<IReadOnlyList<GelatoResponse>>( await _gelatoRepository.GetAllAsync());
        }
        
        public async Task<GelatoResponse> ReadGelatoAsync(int id)
        {
            return _mapper.Map<GelatoResponse>(await _gelatoRepository.GetByIdAsync(id));
        }

        public async Task<GelatoResponse> CreateGelatoAsync(GelatoCreateRequest gelatoCreateRequest)
        {
            var gelato = _mapper.Map<Gelato>(gelatoCreateRequest);
            return _mapper.Map<GelatoResponse>(await _gelatoRepository.AddAsync(gelato));
        }

        public async Task<GelatoResponse> UpdateGelatoAsync(GelatoUpdateRequest gelatoUpdateRequest)
        {
            var gelato = _mapper.Map<Gelato>(gelatoUpdateRequest);
            await _gelatoRepository.UpdateAsync(gelato);
        }

        public Task<GelatoResponse> DeleteGelatoAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
