using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CountryLocalizationMapping : EntityMappingConfiguration<CountryLocalization>
	{
		public override void Map(EntityTypeBuilder<CountryLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_country");
			b.Property(m => m.Name).HasMaxLength(100).IsRequired();
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}