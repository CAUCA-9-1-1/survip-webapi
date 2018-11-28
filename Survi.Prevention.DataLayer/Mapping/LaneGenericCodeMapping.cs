using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class LaneGenericCodeMapping : BaseImportedModelMapping<LaneGenericCode>
	{
		public override void Map(EntityTypeBuilder<LaneGenericCode> b)
		{
			b.Property(m => m.Code).HasMaxLength(1).IsRequired();
			b.Property(m => m.Description).HasMaxLength(15).IsRequired();
		}
	}
}