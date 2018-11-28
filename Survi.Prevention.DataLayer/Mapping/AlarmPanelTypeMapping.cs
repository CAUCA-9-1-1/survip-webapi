using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class AlarmPanelTypeMapping : BaseImportedModelMapping<AlarmPanelType>
	{
		public override void Map(EntityTypeBuilder<AlarmPanelType> b)
		{
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}