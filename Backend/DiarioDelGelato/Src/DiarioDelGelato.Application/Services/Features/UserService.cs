using AutoMapper;
using DiarioDelGelato.Application.DTOs.Features.UserDTOs;
using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Exceptions;
using DiarioDelGelato.Application.Interfaces.Repositories;
using DiarioDelGelato.Application.Interfaces.Services.Features;
using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Services.Features
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync _userRespositoryAsync;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UserService(IUserRepositoryAsync UserRespositoryAsync, IPasswordService passwordService, IMapper mapper)      
        {
            _userRespositoryAsync = UserRespositoryAsync;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        async Task<ServiceResponse<IReadOnlyList<UserResponseDto>>> IUserService.ReadUsersAsync()
        {
            var users = await _userRespositoryAsync.GetAllAsync();
            return new ServiceResponse<IReadOnlyList<UserResponseDto>>(_mapper.Map<IReadOnlyList<UserResponseDto>>(users));
        }

        async Task<ServiceResponse<UserResponseDto>> IUserService.ReadUserByIdAsync(int id)
        {
            var user = await _userRespositoryAsync.GetByIdAsync(id);
            if (user == null)
                return new ServiceResponse<UserResponseDto>("User not found!");

            return new ServiceResponse<UserResponseDto>(_mapper.Map<UserResponseDto>(user));
        }

        async Task<ServiceResponse<UserResponseDto>> IUserService.ReadUserByUsernameAsync(string userName)
        {
            var user = await _userRespositoryAsync.FindByNameAsync(userName);
            if (user == null)
                return new ServiceResponse<UserResponseDto>("User not found!");

            return new ServiceResponse<UserResponseDto>(_mapper.Map<UserResponseDto>(user));

        }

        public async Task<ServiceResponse<UserResponseDto>> CreateUserAsync(UserCreateRequestDto userCreateRequestDto)
        {
            // check if username is at least 3 characters long
            if (String.IsNullOrEmpty(userCreateRequestDto.UserName) || userCreateRequestDto.UserName.Length < 3)
                return new ServiceResponse<UserResponseDto>("Username must be at least 3 characters long");
            
            // check if password is at least 6 characters long
            if (String.IsNullOrEmpty(userCreateRequestDto.Password) || userCreateRequestDto.Password.Length < 6)
                return new ServiceResponse<UserResponseDto>("Password must be at least 6 characters long");
            
            // check if username is already taken
            var existingUser = await _userRespositoryAsync.FindByNameAsync(userCreateRequestDto.UserName);
            if (existingUser != null)
                return new ServiceResponse<UserResponseDto>("Username already taken");

            // map dto to entity
            var user = _mapper.Map<User>(userCreateRequestDto);
            if (user == null)
                return new ServiceResponse<UserResponseDto>("Failed to map user");

            // hash password
            _passwordService.CreatePasswordHash(userCreateRequestDto.Password, out string calculatedPasswordHash, out string calculatedPasswordSalt);

            user.PasswordHash = calculatedPasswordHash;
            user.PasswordSalt = calculatedPasswordSalt;

            // add user to database
            var newUser = await _userRespositoryAsync.AddAsync(user);
            if (newUser == null)
                return new ServiceResponse<UserResponseDto>("Failed to add user to database");

            return new ServiceResponse<UserResponseDto>(_mapper.Map<UserResponseDto>(newUser));
                
        }

        public async Task<ServiceResponse<bool>> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto)
        {
            var user = await _userRespositoryAsync.GetByIdAsync(userUpdateRequestDto.Id);
            if (user == null)
                return new ServiceResponse<bool>("User not found");

            _userRespositoryAsync.UpdateAsync(_mapper.Map<User>(userUpdateRequestDto));
            
            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteUserAsync(int id)
        {
            var user = await _userRespositoryAsync.GetByIdAsync(id);
            if (user == null)
                return new ServiceResponse<bool>("User not found");

            await _userRespositoryAsync.DeleteAsync(user);

            return new ServiceResponse<bool>(true);

        }

        public async Task<ServiceResponse<UserAuthenticationDataReponseDto>> GetUserPasswordDataAsync(int userId)
        {
            var user = await _userRespositoryAsync.GetByIdAsync(userId);
            if (user == null)
                return new ServiceResponse<UserAuthenticationDataReponseDto>($"User with ID {userId} not found.");
            
            if (String.IsNullOrWhiteSpace(user.PasswordHash) || String.IsNullOrWhiteSpace(user.PasswordSalt))
                return new ServiceResponse<UserAuthenticationDataReponseDto>("Unauthorized! Not able to retrive the password.");

            return new ServiceResponse<UserAuthenticationDataReponseDto>(_mapper.Map<UserAuthenticationDataReponseDto>(user));
        }
    }
}
