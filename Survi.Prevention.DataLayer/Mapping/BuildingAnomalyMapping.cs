using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingAnomalyMapping : BaseImportedModelMapping<BuildingAnomaly>
	{
		public override void Map(EntityTypeBuilder<BuildingAnomaly> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.Property(m => m.Theme).IsRequired().HasMaxLength(50);
			b.HasMany(m => m.Pictures).WithOne(m => m.Anomaly).HasForeignKey(m => m.IdBuildingAnomaly);
		}
	}
}