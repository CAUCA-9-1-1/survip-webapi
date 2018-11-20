using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SidingTypeMapping: EntityMappingConfiguration<SidingType>
	{
		public override void Map(EntityTypeBuilder<SidingType> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}