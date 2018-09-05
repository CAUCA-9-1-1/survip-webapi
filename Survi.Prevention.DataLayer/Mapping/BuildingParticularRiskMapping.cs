using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingParticularRiskMapping : EntityMappingConfiguration<BuildingParticularRisk>
	{
		public override void Map(EntityTypeBuilder<BuildingParticularRisk> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);
			b.Property(m => m.Wall).HasMaxLength(15);
			b.Property(m => m.Sector).HasMaxLength(15);
			b.Property(m => m.Dimension).HasMaxLength(100);

			b.HasMany(m => m.Pictures).WithOne(m => m.Risk).HasForeignKey(m => m.IdBuildingParticularRisk);

			b.HasDiscriminator<int>("risk_type")
				.HasValue<BuildingFoundationParticularRisk>((int)ParticularRiskType.Foundation)
				.HasValue<BuildingFloorParticularRisk>((int)ParticularRiskType.Floor)
				.HasValue<BuildingWallParticularRisk>((int)ParticularRiskType.Wall)
				.HasValue<BuildingRoofParticularRisk>((int)ParticularRiskType.Roof);
		}
	}
}