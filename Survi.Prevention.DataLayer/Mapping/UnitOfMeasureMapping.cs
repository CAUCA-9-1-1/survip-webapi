using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UnitOfMeasureMapping : EntityMappingConfiguration<UnitOfMeasure>
	{
		public override void Map(EntityTypeBuilder<UnitOfMeasure> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.Abbreviation).HasMaxLength(5).IsRequired();
			b.Property(m => m.MeasureType).HasMaxLength(20).IsRequired();
		}
	}
}