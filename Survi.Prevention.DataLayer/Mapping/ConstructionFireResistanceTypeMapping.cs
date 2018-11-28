using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class ConstructionFireResistanceTypeMapping : BaseImportedModelMapping<ConstructionFireResistanceType>
	{
		public override void Map(EntityTypeBuilder<ConstructionFireResistanceType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}