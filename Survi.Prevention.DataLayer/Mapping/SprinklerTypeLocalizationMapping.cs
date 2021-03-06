using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SprinklerTypeLocalizationMapping : EntityMappingConfiguration<SprinklerTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<SprinklerTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_sprinkler_type");
			b.Property(m => m.Name).IsRequired().HasMaxLength(50);
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}