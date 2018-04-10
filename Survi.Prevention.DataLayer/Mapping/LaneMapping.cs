using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class LaneMapping : EntityMappingConfiguration<Lane>
	{
		public override void Map(EntityTypeBuilder<Lane> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.LaneGenericCode).WithMany().HasForeignKey(m => m.IdLaneGenericCode);
			b.HasOne(m => m.PublicCode).WithMany().HasForeignKey(m => m.IdPublicCode);
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}