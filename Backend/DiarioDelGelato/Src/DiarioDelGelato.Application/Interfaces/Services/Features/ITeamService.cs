using DiarioDelGelato.Application.DTOs.Features.TeamDTOs;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Features
{
    // implements CRUD services using repository
    public interface ITeamService
    {
        Task<IReadOnlyList<TeamMemberResponseDto>> GetTeamAsync();
        Task<ServiceResponse<TeamMemberResponseDto>> GetTeamMemberAsync(int id);
        Task<ServiceResponse<TeamMemberResponseDto>> CreateTeamMemberAsync(TeamMemberCreateRequestDto teamMemberCreateRequest);
        Task<ServiceResponse<bool>> UpdateTeamMemberAsync(TeamMemberUpdateRequestDto teamMemberUpdateRequest);
        Task<ServiceResponse<bool>> DeleteTeamMemberAsync(int id);
        Task<bool> TeamMemberExistsAsync(string teamMemberFullName);

    }
}
