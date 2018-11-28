using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class HazardousMaterialMapping : BaseImportedModelMapping<HazardousMaterial>
	{
		public override void Map(EntityTypeBuilder<HazardousMaterial> b)
		{			
			b.Property(m => m.Number).HasMaxLength(50).IsRequired();
			b.Property(m => m.GuideNumber).HasMaxLength(255).IsRequired();
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}