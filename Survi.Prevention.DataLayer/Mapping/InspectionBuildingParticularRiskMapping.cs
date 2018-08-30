using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingParticularRiskMapping : EntityMappingConfiguration<InspectionBuildingParticularRisk>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingParticularRisk> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Wall).HasMaxLength(15);
			b.Property(m => m.Sector).HasMaxLength(15);
			b.Property(m => m.Dimension).HasMaxLength(100);

			b.HasMany(m => m.Pictures).WithOne(m => m.Risk).HasForeignKey(m => m.IdBuildingParticularRisk).OnDelete(DeleteBehavior.Cascade);

			b.HasDiscriminator<int>("risk_type")
				.HasValue<InspectionBuildingFoundationParticularRisk>(0)
				.HasValue<InspectionBuildingFloorParticularRisk>(1)
				.HasValue<InspectionBuildingWallParticularRisk>(2)
				.HasValue<InspectionBuildingRoofParticularRisk>(3);
		}
	}
}