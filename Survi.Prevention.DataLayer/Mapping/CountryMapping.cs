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
			b.HasKey(m => m.Id);

			b.Property(m => m.CodeAlpha2).HasMaxLength(2).IsRequired();
			b.Property(m => m.CodeAlpha3).HasMaxLength(3).IsRequired();
			b.HasMany(m => m.States).WithOne(m => m.Country).HasForeignKey(m => m.IdCountry);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}