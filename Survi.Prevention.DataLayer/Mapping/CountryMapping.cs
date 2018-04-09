using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CountryMapping : EntityMappingConfiguration<Country>
	{
		public override void Map(EntityTypeBuilder<Country> b)
		{
			b.ToTable("tbl_country").HasKey(m => m.Id);

			b.Property(m => m.CodeAlpha2).HasColumnName("code_alpha2").HasMaxLength(2).IsRequired();
			b.Property(m => m.CodeAlpha3).HasColumnName("code_alpha3").HasMaxLength(3).IsRequired();
			b.Property(m => m.Id).HasColumnName("id_country");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.States).WithOne(m => m.Country).HasForeignKey(m => m.IdCountry);
		}
	}
}