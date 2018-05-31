using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class HazardousMaterialLocalizationMapping : EntityMappingConfiguration<HazardousMaterialLocalization>
	{
		public override void Map(EntityTypeBuilder<HazardousMaterialLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_hazardous_material");
			b.Property(m => m.Name).HasMaxLength(250).IsRequired();
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
			b.HasIndex(m => new { m.IdParent, m.IsActive, m.LanguageCode });
		}
	}
}