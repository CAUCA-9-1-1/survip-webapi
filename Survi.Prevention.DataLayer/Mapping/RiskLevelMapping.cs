using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class RiskLevelMapping : BaseImportedModelMapping<RiskLevel>
	{
		public override void Map(EntityTypeBuilder<RiskLevel> b)
		{
			b.Property(m => m.Sequence).IsRequired();
			b.Property(m => m.Color).HasMaxLength(50).IsRequired();
			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}