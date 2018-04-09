using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class HazardousMaterialMapping : EntityMappingConfiguration<HazardousMaterial>
	{
		public override void Map(EntityTypeBuilder<HazardousMaterial> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Number).HasMaxLength(50).IsRequired();
			b.Property(m => m.GuideNumber).HasMaxLength(255).IsRequired();
			b.Property(m => m.ReactToWater).IsRequired();
			b.Property(m => m.ToxicInhalationHazard).IsRequired();
			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}
}