using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PermissionSystemMapping : EntityMappingConfiguration<PermissionSystem>
	{
		public override void Map(EntityTypeBuilder<PermissionSystem> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Description).HasMaxLength(400).IsRequired();
		}
	}
}