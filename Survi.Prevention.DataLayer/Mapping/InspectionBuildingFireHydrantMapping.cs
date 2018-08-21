using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingFireHydrantMapping : EntityMappingConfiguration<InspectionBuildingFireHydrant>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingFireHydrant> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}
}