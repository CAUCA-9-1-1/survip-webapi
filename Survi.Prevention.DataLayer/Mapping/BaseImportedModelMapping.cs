using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.DataLayer.Mapping
{
    public abstract class BaseImportedModelMapping<T> : BaseModelMapping<T>
        where T: BaseImportedModel
    {
        public override void Map(ModelBuilder b)
        {
            base.Map(b);
            b.Entity<T>().Property(m => m.IdExtern).HasMaxLength(100);
        }
    }
}