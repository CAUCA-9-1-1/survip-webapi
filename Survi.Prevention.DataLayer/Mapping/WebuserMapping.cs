using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class WebuserMapping : EntityMappingConfiguration<Webuser>
	{
		public override void Map(EntityTypeBuilder<Webuser> b)
		{
			b.HasKey(p => p.Id);

			b.Property(p => p.Username).HasMaxLength(100).IsRequired();
			b.Property(p => p.Password).HasMaxLength(100).IsRequired();

			b.HasMany(p => p.Attributes)
				.WithOne(p => p.User)
				.HasForeignKey(p => p.IdWebuser);

			b.HasMany(p => p.FireSafetyDepartments)
				.WithOne(p => p.User)
				.HasForeignKey(p => p.IdWebuser);
		}
	}
}