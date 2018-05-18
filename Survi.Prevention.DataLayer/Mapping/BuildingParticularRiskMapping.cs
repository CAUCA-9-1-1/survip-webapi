using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingParticularRiskMapping : EntityMappingConfiguration<BuildingParticularRisk>
	{
		public override void Map(EntityTypeBuilder<BuildingParticularRisk> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Wall).HasMaxLength(15).IsRequired();
			b.Property(m => m.Sector).HasMaxLength(15).IsRequired();
			b.Property(m => m.Dimension).HasMaxLength(100).IsRequired();

			b.HasMany(m => m.Pictures).WithOne(m => m.Risk).HasForeignKey(m => m.IdBuildingParticularRisk);

			b.HasDiscriminator<int>("risk_type")
				.HasValue<FoundationParticularRisk>(0)
				.HasValue<FloorParticularRisk>(1)
				.HasValue<WallParticularRisk>(2)
				.HasValue<RoofParticularRisk>(3);
		}
	}
}