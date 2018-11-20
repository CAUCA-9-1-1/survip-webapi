using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UtilisationCodeMapping : EntityMappingConfiguration<UtilisationCode>
	{
		public override void Map(EntityTypeBuilder<UtilisationCode> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Cubf).HasMaxLength(5).IsRequired();
			b.Property(m => m.Scian).HasMaxLength(10).IsRequired();
			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}