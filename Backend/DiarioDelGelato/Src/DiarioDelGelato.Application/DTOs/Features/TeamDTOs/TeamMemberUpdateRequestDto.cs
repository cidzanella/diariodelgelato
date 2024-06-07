using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Features.TeamDTOs
{
    public class TeamMemberUpdateRequestDto : TeamMemberCreateRequestDto
    {
        [Required]
        public int Id { get; set; }

    }
}
