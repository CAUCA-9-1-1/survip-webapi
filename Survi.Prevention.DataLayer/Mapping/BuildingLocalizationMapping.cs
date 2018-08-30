using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingLocalizationMapping : EntityMappingConfiguration<BuildingLocalization>
	{
		public override void Map(EntityTypeBuilder<BuildingLocalization> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_building");
			b.Property(m => m.Name).IsRequired().HasMaxLength(250);
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}