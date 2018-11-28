using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SidingTypeMapping: BaseImportedModelMapping<SidingType>
	{
		public override void Map(EntityTypeBuilder<SidingType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}