using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingCourseLaneMapping : BaseImportedModelMapping<BuildingCourseLane>
	{
		public override void Map(EntityTypeBuilder<BuildingCourseLane> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
		}
	}
}