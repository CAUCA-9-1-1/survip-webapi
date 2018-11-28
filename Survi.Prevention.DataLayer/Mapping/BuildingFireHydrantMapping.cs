using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingFireHydrantMapping : BaseImportedModelMapping<BuildingFireHydrant>
	{
		public override void Map(EntityTypeBuilder<BuildingFireHydrant> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}
}