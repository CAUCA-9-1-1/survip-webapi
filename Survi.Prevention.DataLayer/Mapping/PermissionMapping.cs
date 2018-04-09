using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionMapping : EntityMappingConfiguration<Permission>
	{
		public override void Map(EntityTypeBuilder<Permission> b)
		{
			b.ToTable("tbl_permission")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_permission");
			b.Property(m => m.IdPermissionObject).HasColumnName("id_permission_object");
			b.Property(m => m.IdPermissionSystem).HasColumnName("id_permission_system");
			b.Property(m => m.IdPermissionSystemFeature).HasColumnName("id_permission_system_feature");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.Comments).HasColumnName("comments").HasMaxLength(400);
			b.Property(m => m.Access).HasColumnName("access").IsRequired();

			b.HasOne(m => m.PermissionObject)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionObject);
			b.HasOne(m => m.System)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionSystem);
			b.HasOne(m => m.Feature)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionSystemFeature);
		}
	}
}