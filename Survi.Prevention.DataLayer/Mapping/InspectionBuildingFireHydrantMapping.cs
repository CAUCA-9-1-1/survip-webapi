using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingFireHydrantMapping : BaseImportedModelMapping<InspectionBuildingFireHydrant>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingFireHydrant> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}
}