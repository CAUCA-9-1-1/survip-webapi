using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantConnectionMapping : BaseImportedModelMapping<FireHydrantConnection>
	{
		public override void Map(EntityTypeBuilder<FireHydrantConnection> b)
		{
			b.HasOne(m => m.DiameterUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureDiameter);
			b.HasOne(m => m.ConnectionType).WithMany().HasForeignKey(m => m.IdFireHydrantConnectionType);
		}
	}
}