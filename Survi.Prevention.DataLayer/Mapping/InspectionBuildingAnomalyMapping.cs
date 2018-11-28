using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingAnomalyMapping : BaseImportedModelMapping<InspectionBuildingAnomaly>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingAnomaly> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.Property(m => m.Theme).IsRequired().HasMaxLength(50);
			b.HasMany(m => m.Pictures).WithOne(m => m.Anomaly).HasForeignKey(m => m.IdBuildingAnomaly).OnDelete(DeleteBehavior.Cascade);
		}
	}
}