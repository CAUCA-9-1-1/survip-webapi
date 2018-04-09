using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantConnectionTypeLocalizationMapping : EntityMappingConfiguration<FireHydrantConnectionTypeLocalization>
	{
		public override void Map(EntityTypeBuilder<FireHydrantConnectionTypeLocalization> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.IdParent).HasColumnName("id_fire_hydrant_connection_type");
		}
	}
}