using DiarioDelGelato.Domain.Common;

namespace DiarioDelGelato.Domain.Entities
{
    public class TeamMember : BaseEntity
    {
        public string FullName { get; set; }

        public string PersonalId { get; set; }

        public long WorkStartHour { get; set; } //INTEGER as Unix Time, the number of seconds since 1970-01-01 00:00:00 UTC.

        public long WorkStopHour { get; set; }

        public long BreakStartHour { get; set; }

        public long BreakStopHour { get; set; }

        public bool HasCredential { get; set; } //software logon credential => User (identity)

        public string? Photo { get; set; }

    }
}
