using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UnitOfMeasureLocalizationMapping : EntityMappingConfiguration<UnitOfMeasureLocalization>
	{
		public override void Map(EntityTypeBuilder<UnitOfMeasureLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.LanguageCode).IsRequired().HasMaxLength(2);
			b.Property(m => m.Name).IsRequired().HasMaxLength(50);		
		}
	}
}