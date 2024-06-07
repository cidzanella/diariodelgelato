using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Identity
{
    public class AuthenticationResponseDTO
    {
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public string Token { get; set; }

        public bool IsEnabled { get; set; }
    }
}
