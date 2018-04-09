using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionSystemFeatureMapping : EntityMappingConfiguration<PermissionSystemFeature>
	{
		public override void Map(EntityTypeBuilder<PermissionSystemFeature> b)
		{
			b.ToTable("tbl_permission_system_feature")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_permission_system_feature");
			b.Property(m => m.IdPermissionSystem).HasColumnName("id_permission_system");
			b.Property(m => m.FeatureName).HasColumnName("feature_name").HasMaxLength(50).IsRequired();
			b.Property(m => m.Description).HasColumnName("description").HasMaxLength(255).IsRequired();
			b.Property(m => m.DefaultValue).HasColumnName("default_value").IsRequired();

			b.HasOne(m => m.System)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionSystem);
		}
	}
}