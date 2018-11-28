using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantConnectionTypeMapping : BaseImportedModelMapping<FireHydrantConnectionType>
	{
		public override void Map(EntityTypeBuilder<FireHydrantConnectionType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}