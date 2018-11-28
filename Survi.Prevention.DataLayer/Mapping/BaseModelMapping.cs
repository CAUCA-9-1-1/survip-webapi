using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.DataLayer.Mapping
{
    public abstract class BaseModelMapping<T> : EntityMappingConfiguration<T>
        where T : BaseModel
    {
        public override void Map(ModelBuilder b)
        {
            b.Entity<T>().HasKey(m => m.Id);
            Map(b.Entity<T>());
        }
    }
}