using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class RegionMapping : EntityMappingConfiguration<Region>
	{
		public override void Map(EntityTypeBuilder<Region> b)
		{
			b.ToTable("tbl_region").HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_country");
			b.Property(m => m.IdState).HasColumnName("id_state").IsRequired();
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.Counties).WithOne(m => m.Region).HasForeignKey(m => m.IdRegion);
		}
	}
}