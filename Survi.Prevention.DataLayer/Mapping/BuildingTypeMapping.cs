using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingTypeMapping : EntityMappingConfiguration<BuildingType>
	{
		public override void Map(EntityTypeBuilder<BuildingType> b)
		{
			b.HasKey(m => m.Id);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}