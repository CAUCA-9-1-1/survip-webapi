using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InterventionFormCourseLaneMapping : EntityMappingConfiguration<InterventionFormCourseLane>
	{
		public override void Map(EntityTypeBuilder<InterventionFormCourseLane> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
		}
	}
}