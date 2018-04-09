using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class PublicCodeMapping : EntityMappingConfiguration<LanePublicCode>
	{
		public override void Map(EntityTypeBuilder<LanePublicCode> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Code).HasMaxLength(2).IsRequired();
			b.Property(m => m.Description).HasMaxLength(20).IsRequired();
			b.Property(m => m.Abbreviation).HasMaxLength(2).IsRequired();
		}
	}
}