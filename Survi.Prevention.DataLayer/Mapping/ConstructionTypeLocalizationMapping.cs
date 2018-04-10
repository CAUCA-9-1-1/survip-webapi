using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class ConstructionTypeLocalizationMapping : EntityMappingConfiguration<ConstructionTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<ConstructionTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_construction_type");
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}