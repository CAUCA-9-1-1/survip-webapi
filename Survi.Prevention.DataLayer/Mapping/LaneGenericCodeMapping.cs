using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class LaneGenericCodeMapping : EntityMappingConfiguration<LaneGenericCode>
	{
		public override void Map(EntityTypeBuilder<LaneGenericCode> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Code).HasMaxLength(1).IsRequired();
			b.Property(m => m.Description).HasMaxLength(15).IsRequired();
		}
	}
}