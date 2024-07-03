using DiarioDelGelato.Application.DTOs.Features.UserDTOs;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Features
{
    // CRUD for Application User
    public interface IUserService
    {
        Task<ServiceResponse<IReadOnlyList<UserResponseDto>>> ReadUsersAsync();
        Task<ServiceResponse<UserResponseDto>> ReadUserByIdAsync(int id);
        Task<ServiceResponse<UserResponseDto>> ReadUserByUsernameAsync(string userName);
        Task<ServiceResponse<UserResponseDto>> CreateUserAsync(UserCreateRequestDto userCreateRequestDto);
        Task<ServiceResponse<bool>> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto);
        Task<ServiceResponse<bool>> DeleteUserAsync(int id);
        Task<ServiceResponse<UserAuthenticationDataReponseDto>> GetUserPasswordDataAsync(int userId);
    }
}
