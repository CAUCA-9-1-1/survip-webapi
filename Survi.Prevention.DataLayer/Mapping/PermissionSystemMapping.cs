using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionSystemMapping : EntityMappingConfiguration<PermissionSystem>
	{
		public override void Map(EntityTypeBuilder<PermissionSystem> b)
		{
			b.ToTable("tbl_permission_system")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_permission_system");
			b.Property(m => m.Description).HasColumnName("description").HasMaxLength(400).IsRequired();
		}
	}
}