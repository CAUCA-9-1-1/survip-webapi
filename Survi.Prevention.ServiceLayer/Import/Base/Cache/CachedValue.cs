using System;

namespace Survi.Prevention.ServiceLayer.Import.Base.Cache
{
    public class CachedForeignKey
    {
        public Guid Id { get; set; }
        public Type Type { get; set; }
        public String ExternalId { get; set; }
        public DateTime ExpiredAt { get; } = DateTime.Now.AddMinutes(30);
    }
}
