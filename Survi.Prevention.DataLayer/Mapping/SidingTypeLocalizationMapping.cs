using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SidingTypeLocalizationMapping : EntityMappingConfiguration<SidingTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<SidingTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_siding_type");
			b.Property(m => m.Name).IsRequired().HasMaxLength(50);
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}