using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingCourseLaneMapping : EntityMappingConfiguration<BuildingCourseLane>
	{
		public override void Map(EntityTypeBuilder<BuildingCourseLane> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
		}
	}
}