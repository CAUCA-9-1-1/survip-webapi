using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UtilisationCodeLocalizationMapping : EntityMappingConfiguration<UtilisationCodeLocalization>
	{
		public override void Map(EntityTypeBuilder<UtilisationCodeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_utilisation_code");
		}
	}
}