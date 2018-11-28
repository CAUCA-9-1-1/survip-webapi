using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UnitOfMeasureMapping : BaseImportedModelMapping<UnitOfMeasure>
	{
		public override void Map(EntityTypeBuilder<UnitOfMeasure> b)
		{
			b.Property(m => m.Abbreviation).HasMaxLength(5).IsRequired();
			b.HasMany(m => m.Localizations).WithOne().HasForeignKey(m => m.IdParent);
		}
	}
}