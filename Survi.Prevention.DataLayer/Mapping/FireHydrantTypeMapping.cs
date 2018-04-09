using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantTypeMapping : EntityMappingConfiguration<FireHydrantType>
	{
		public override void Map(EntityTypeBuilder<FireHydrantType> b)
		{
			b.HasKey(m => m.Id);
		}
	}
}