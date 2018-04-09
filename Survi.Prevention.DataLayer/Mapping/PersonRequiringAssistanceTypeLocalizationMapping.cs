using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PersonRequiringAssistanceTypeLocalizationMapping : EntityMappingConfiguration<PersonRequiringAssistanceTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<PersonRequiringAssistanceTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_person_requiring_assistance_type");
		}
	}
}