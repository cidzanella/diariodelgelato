using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Features.UserDTOs
{
    public class UserUpdateRequestDto
    {
        [Required]
        public int Id { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsEnabled { get; set; }
    }
}
