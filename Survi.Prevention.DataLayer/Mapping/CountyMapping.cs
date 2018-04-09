using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CountyMapping : EntityMappingConfiguration<County>
	{
		public override void Map(EntityTypeBuilder<County> b)
		{
			b.ToTable("tbl_county").HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_county");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.Cities).WithOne(m => m.County).HasForeignKey(m => m.IdCounty);
			b.HasMany(m => m.FireSafetyDepartments).WithOne(m => m.County).HasForeignKey(m => m.IdCounty);
		}
	}
}