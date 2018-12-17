using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.Import.Base.Cache
{
    public class CacheSystem
    {
        private readonly HashSet<CachedForeignKey> foreignKeys = new HashSet<CachedForeignKey>();

        public Guid? GetForeignKey(Type type, string externalId)
        {
            CleanCache();
            var id = foreignKeys
                .FirstOrDefault(key => key.Type == type && key.ExternalId == externalId)?.Id;
            return id;
        }

        public void SetForeignKeys(Type type, string externalId, Guid id)
        {
            foreignKeys.Add(new CachedForeignKey { Type = type, Id = id, ExternalId = externalId});
        }

        private void CleanCache()
        {
            foreignKeys
                .RemoveWhere(key => key.ExpiredAt <= DateTime.Now);
        }
    }
}