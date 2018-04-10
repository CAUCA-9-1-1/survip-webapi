using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionMapping : EntityMappingConfiguration<Permission>
	{
		public override void Map(EntityTypeBuilder<Permission> b)
		{
			b.HasKey(m => m.Id);

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