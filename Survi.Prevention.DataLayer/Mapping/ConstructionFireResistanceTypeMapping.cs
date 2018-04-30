using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class ConstructionFireResistanceTypeMapping : EntityMappingConfiguration<ConstructionFireResistanceType>
	{
		public override void Map(EntityTypeBuilder<ConstructionFireResistanceType> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}