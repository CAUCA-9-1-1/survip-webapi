using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingCourseLaneMapping : EntityMappingConfiguration<InspectionBuildingCourseLane>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingCourseLane> b)
		{
			b.HasKey(m => m.Id);
			//b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
		}
	}
}