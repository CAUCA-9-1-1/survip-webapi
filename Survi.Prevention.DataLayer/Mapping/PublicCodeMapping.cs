using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PublicCodeMapping : BaseImportedModelMapping<LanePublicCode>
	{
		public override void Map(EntityTypeBuilder<LanePublicCode> b)
		{
			b.Property(m => m.Code).HasMaxLength(2).IsRequired();
			b.Property(m => m.Description).HasMaxLength(20).IsRequired();
			b.Property(m => m.Abbreviation).HasMaxLength(2).IsRequired();
		}
	}
}