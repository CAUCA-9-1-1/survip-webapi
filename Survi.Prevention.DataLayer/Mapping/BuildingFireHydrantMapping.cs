using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingFireHydrantMapping : EntityMappingConfiguration<BuildingFireHydrant>
	{
		public override void Map(EntityTypeBuilder<BuildingFireHydrant> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}

	public class InspectionBuildingFireHydrantMapping : EntityMappingConfiguration<InspectionBuildingFireHydrant>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingFireHydrant> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Hydrant).WithMany().HasForeignKey(m => m.IdFireHydrant);
		}
	}
}