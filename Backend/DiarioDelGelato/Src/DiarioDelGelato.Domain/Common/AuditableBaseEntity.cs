using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; } 
        public int Created { get; set; } //INTEGER as Unix Time, the number of seconds since 1970-01-01 00:00:00 UTC.
        public string LastModifiedBy { get; set; }
        public int? LastModified { get; set; }
    }
}
