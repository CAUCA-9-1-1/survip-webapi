using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class RiskLevelMapping : EntityMappingConfiguration<RiskLevel>
	{
		public override void Map(EntityTypeBuilder<RiskLevel> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Sequence).IsRequired();
			b.Property(m => m.Color).HasMaxLength(50).IsRequired();
			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}