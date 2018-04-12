using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionObjectMapping : EntityMappingConfiguration<PermissionObject>
	{
		public override void Map(EntityTypeBuilder<PermissionObject> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.ObjectTable).HasMaxLength(255).IsRequired();
			b.Property(m => m.GenericId).HasMaxLength(50);
			b.Property(m => m.GroupName).HasMaxLength(50);

			b.HasOne(m => m.System)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionSystem);

			b.HasOne(m => m.Parent)
				.WithMany()
				.HasForeignKey(m => m.IdPermissionObjectParent);
		}
	}
}