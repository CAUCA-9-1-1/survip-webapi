using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class LaneMapping : BaseImportedModelMapping<Lane>
	{
		public override void Map(EntityTypeBuilder<Lane> b)
		{
			b.HasOne(m => m.LaneGenericCode).WithMany().HasForeignKey(m => m.IdLaneGenericCode);
			b.HasOne(m => m.PublicCode).WithMany().HasForeignKey(m => m.IdPublicCode);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}