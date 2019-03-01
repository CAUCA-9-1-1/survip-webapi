using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UtilisationCodeMapping : BaseImportedModelMapping<UtilisationCode>
	{
		public override void Map(EntityTypeBuilder<UtilisationCode> b)
		{
			b.Property(m => m.Cubf).HasMaxLength(5).IsRequired();
			b.Property(m => m.Scian).HasMaxLength(25).IsRequired();
			b.Property(m => m.Year);
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}