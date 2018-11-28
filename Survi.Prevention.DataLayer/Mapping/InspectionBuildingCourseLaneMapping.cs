using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingCourseLaneMapping : BaseImportedModelMapping<InspectionBuildingCourseLane>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingCourseLane> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
		}
	}
}