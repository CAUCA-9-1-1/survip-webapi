using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class ConstructionTypeMapping : BaseImportedModelMapping<ConstructionType>
	{
		public override void Map(EntityTypeBuilder<ConstructionType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}