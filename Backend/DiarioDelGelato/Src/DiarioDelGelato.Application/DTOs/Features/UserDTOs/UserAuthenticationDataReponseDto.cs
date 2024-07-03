using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Features.UserDTOs
{
    public class UserAuthenticationDataReponseDto : UserResponseDto
    {
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
