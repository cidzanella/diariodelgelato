using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs.Features.ConoDelGiornoDTOs
{
    public class ConoDelGiornoResponseDto
    {
        public int Id { get; set; }

        public int TeamMemberId { get; set; }

        public int GelatoAId { get; set; }

        public int GelatoBId { get; set; }

        public int Weight { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
