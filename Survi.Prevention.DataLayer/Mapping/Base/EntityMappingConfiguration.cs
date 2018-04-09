using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.DataLayer.Mapping.Base
{
	public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
	{
		public abstract void Map(EntityTypeBuilder<T> b);

		public virtual void Map(ModelBuilder b)
		{
			Map(b.Entity<T>());
		}
	}
}
