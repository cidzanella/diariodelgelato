using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.DTOs
{
    public class GelatoCreateRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class GelatoUpdateRequestDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class GelatoResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}
