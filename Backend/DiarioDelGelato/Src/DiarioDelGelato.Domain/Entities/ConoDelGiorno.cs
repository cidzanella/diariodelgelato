﻿

namespace DiarioDelGelato.Domain.Entities
{
    public class ConoDelGiorno
    {
        public ConoDelGiorno() => this.Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public int TeamMemberId { get; set; } //who is the gelato for
        public int GelatoAId { get; set; }
        public int GelatoBId { get; set; }
        public int Weight { get; set; }
        public long Timestamp { get; set; } //INTEGER as Unix Time, the number of seconds since 1970-01-01 00:00:00 UTC. Use DateTime.UtcNow and 
    }
}
