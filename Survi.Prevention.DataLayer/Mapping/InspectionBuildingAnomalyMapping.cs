using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingAnomalyMapping : EntityMappingConfiguration<InspectionBuildingAnomaly>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingAnomaly> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);
			b.Property(m => m.Theme).IsRequired().HasMaxLength(50);
			b.HasMany(m => m.Pictures).WithOne(m => m.Anomaly).HasForeignKey(m => m.IdBuildingAnomaly).OnDelete(DeleteBehavior.Cascade);
		}
	}
}