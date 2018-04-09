using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantConnectionTypeMapping : EntityMappingConfiguration<FireHydrantConnectionType>
	{
		public override void Map(EntityTypeBuilder<FireHydrantConnectionType> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}