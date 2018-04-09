using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class RegionMapping : EntityMappingConfiguration<Region>
	{
		public override void Map(EntityTypeBuilder<Region> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Counties).WithOne(m => m.Region).HasForeignKey(m => m.IdRegion);
		}
	}
}