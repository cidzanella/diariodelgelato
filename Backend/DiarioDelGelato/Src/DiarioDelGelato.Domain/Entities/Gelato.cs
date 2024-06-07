using DiarioDelGelato.Domain.Common;

namespace DiarioDelGelato.Domain.Entities
{
    public class Gelato : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
