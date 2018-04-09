using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantTypeLocalizationMapping : EntityMappingConfiguration<FireHydrantTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<FireHydrantTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Name).HasMaxLength(100).IsRequired();
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
			b.Property(m => m.IdParent).HasColumnName("id_fire_hydrant_type");
		}
	}
}