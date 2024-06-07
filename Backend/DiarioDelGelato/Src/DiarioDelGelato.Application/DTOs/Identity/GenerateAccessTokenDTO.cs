using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Identity
{
    public class GenerateAccessTokenDTO
    {
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
