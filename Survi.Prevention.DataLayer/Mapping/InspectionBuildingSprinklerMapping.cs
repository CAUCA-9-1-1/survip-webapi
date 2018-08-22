using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingSprinklerMapping : EntityMappingConfiguration<InspectionBuildingSprinkler>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingSprinkler> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Floor).HasMaxLength(100);
			b.Property(m => m.Wall).HasMaxLength(100);
			b.Property(m => m.Sector).HasMaxLength(100);
			b.HasOne(m => m.SprinklerType).WithMany().HasForeignKey(m => m.IdSprinklerType);
		}
	}
}