using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class SprinklerTypeMapping : BaseImportedModelMapping<SprinklerType>
	{
		public override void Map(EntityTypeBuilder<SprinklerType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}