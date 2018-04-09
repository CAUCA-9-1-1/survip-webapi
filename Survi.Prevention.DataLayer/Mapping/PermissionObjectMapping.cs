using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionObjectMapping : EntityMappingConfiguration<PermissionObject>
	{
		public override void Map(EntityTypeBuilder<PermissionObject> b)
		{
			b.ToTable("tbl_permission_object")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_permission_object");
			b.Property(m => m.IdPermissionObjectParent).HasColumnName("id_permission_object_parent");
			b.Property(m => m.ObjectTable).HasColumnName("object_table").HasMaxLength(255).IsRequired();
			b.Property(m => m.GenericId).HasColumnName("generic_id").HasMaxLength(50);
			b.Property(m => m.IdPermissionSystem).HasColumnName("id_permission_system").IsRequired();
			b.Property(m => m.IdPermissionObjectParent).HasColumnName("id_permission_object_parent");

			b.HasOne(m => m.System)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionSystem);

			b.HasOne(m => m.Parent)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionObjectParent);
		}
	}
}