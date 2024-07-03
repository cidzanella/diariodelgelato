using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Features.UserDTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsEnabled { get; set; }
    }
}
