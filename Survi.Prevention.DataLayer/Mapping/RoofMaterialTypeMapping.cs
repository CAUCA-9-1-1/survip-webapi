using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class RoofMaterialTypeMapping : BaseImportedModelMapping<RoofMaterialType>
	{
		public override void Map(EntityTypeBuilder<RoofMaterialType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}