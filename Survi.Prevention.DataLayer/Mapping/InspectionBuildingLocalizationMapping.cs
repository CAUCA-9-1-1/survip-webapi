using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingLocalizationMapping : EntityMappingConfiguration<InspectionBuildingLocalization>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_building");
			b.Property(m => m.Name).IsRequired().HasMaxLength(250);
			b.Property(m => m.LanguageCode).HasMaxLength(2).IsRequired();
		}
	}
}