using DiarioDelGelato.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Domain.Entities
{
    public class Gelato : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
