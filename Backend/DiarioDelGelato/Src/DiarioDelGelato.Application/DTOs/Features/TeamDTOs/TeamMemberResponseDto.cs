using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Features.TeamDTOs
{
    public class TeamMemberResponseDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string PersonalId { get; set; }

        public long WorkStartHour { get; set; } //INTEGER as Unix Time, the number of seconds since 1970-01-01 00:00:00 UTC.

        public long WorkStopHour { get; set; }

        public long BreakStartHour { get; set; }

        public long BreakStopHour { get; set; }

        public bool HasCredential { get; set; } //software logon credential

        public string? UserName { get; set; } //for logon

        public bool IsAdmin { get; set; }

        public string? Photo { get; set; }

    }
}
