using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantTypeMapping : BaseImportedModelMapping<FireHydrantType>
	{
		public override void Map(EntityTypeBuilder<FireHydrantType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}