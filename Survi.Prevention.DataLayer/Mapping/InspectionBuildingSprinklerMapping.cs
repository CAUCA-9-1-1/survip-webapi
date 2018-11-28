using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingSprinklerMapping : BaseImportedModelMapping<InspectionBuildingSprinkler>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingSprinkler> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.Property(m => m.Floor).HasMaxLength(3);
			b.Property(m => m.Wall).HasMaxLength(3);
			b.Property(m => m.Sector).HasMaxLength(3);
			b.HasOne(m => m.SprinklerType).WithMany().HasForeignKey(m => m.IdSprinklerType);
		}
	}
}