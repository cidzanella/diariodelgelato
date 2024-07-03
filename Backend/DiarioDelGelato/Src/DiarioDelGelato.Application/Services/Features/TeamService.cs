using AutoMapper;
using DiarioDelGelato.Application.DTOs.Features.TeamDTOs;
using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Application.Interfaces.Services.Features;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Services.Features
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepositoryAsync _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepositoryAsync teamRepository, IMapper mapper) 
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<TeamMemberResponseDto>> CreateTeamMemberAsync(TeamMemberCreateRequestDto teamMemberCreateRequest)
        {
            // validate unique member name
            if (await TeamMemberExistsAsync(teamMemberCreateRequest.FullName))
                return new ServiceResponse<TeamMemberResponseDto>("Team member name is already on records.");

            // validate other fields ?
            
            // create
            try
            {
                var teamMember = _mapper.Map<TeamMember>(teamMemberCreateRequest);
                return new ServiceResponse<TeamMemberResponseDto>(_mapper.Map<TeamMemberResponseDto>(await _teamRepository.AddAsync(teamMember)));
            }
            catch (Exception e)
            {
                return new ServiceResponse<TeamMemberResponseDto>($"Error on CreateTeamMemberAsync method :: {e.Message} | {e.InnerException}");
            }
        }

        public Task<ServiceResponse<bool>> DeleteTeamMemberAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TeamMemberResponseDto>> GetTeamAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TeamMemberResponseDto>> GetTeamMemberAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpdateTeamMemberAsync(TeamMemberUpdateRequestDto teamMemberUpdateRequest)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> TeamMemberExistsAsync(string teamMemberFullName)
        {
            return await _teamRepository.TeamMemberExistsAsync(teamMemberFullName);
        }

        Task<bool> ITeamService.TeamMemberExistsAsync(string teamMemberFullName)
        {
            throw new NotImplementedException();
        }
    }
}
