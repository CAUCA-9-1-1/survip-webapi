using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class ConstructionFireResistanceTypeLocalizationMapping : EntityMappingConfiguration<ConstructionFireResistanceTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<ConstructionFireResistanceTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Name).IsRequired().HasMaxLength(50);
			b.Property(m => m.LanguageCode).IsRequired().HasMaxLength(2);
		}
	}
}