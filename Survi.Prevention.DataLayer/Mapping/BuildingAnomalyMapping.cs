using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingAnomalyMapping : EntityMappingConfiguration<BuildingAnomaly>
	{
		public override void Map(EntityTypeBuilder<BuildingAnomaly> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Theme).IsRequired().HasMaxLength(50);
			b.HasMany(m => m.Pictures).WithOne(m => m.Anomaly).HasForeignKey(m => m.IdBuildingAnomaly);
		}
	}
}