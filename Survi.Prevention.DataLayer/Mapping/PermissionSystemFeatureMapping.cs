using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionSystemFeatureMapping : EntityMappingConfiguration<PermissionSystemFeature>
	{
		public override void Map(EntityTypeBuilder<PermissionSystemFeature> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.FeatureName).HasMaxLength(50).IsRequired();
			b.Property(m => m.Description).HasMaxLength(255).IsRequired();

			b.HasOne(m => m.System)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionSystem);
		}
	}
}