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
			b.Property(m => m.Code).HasMaxLength(10).IsRequired();
			b.HasMany(m => m.Counties).WithOne(m => m.Region).HasForeignKey(m => m.IdRegion);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}