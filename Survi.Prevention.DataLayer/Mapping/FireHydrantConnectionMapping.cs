using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantConnectionMapping : EntityMappingConfiguration<FireHydrantConnection>
	{
		public override void Map(EntityTypeBuilder<FireHydrantConnection> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.DiameterUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureDiameter);
			b.HasOne(m => m.ConnectionType).WithMany().HasForeignKey(m => m.IdFireHydrantConnectionType);
		}
	}
}