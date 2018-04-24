using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class UnitOfMeasureMapping : EntityMappingConfiguration<UnitOfMeasure>
	{
		public override void Map(EntityTypeBuilder<UnitOfMeasure> b)
		{
			b.HasDiscriminator<int>("measure_type")
				.HasValue<RateUnitOfMeasure>(0)
				.HasValue<PressureUnitOfMeasure>(1)
				.HasValue<DiameterUnitOfMeasure>(2)
				.HasValue<CapacityUnitOfMeasure>(3)
				.HasValue<DimensionUnitOfMeasure>(4);

			b.HasKey(m => m.Id);

			b.Property(m => m.Abbreviation).HasMaxLength(5).IsRequired();
			b.HasMany(m => m.Localizations).WithOne(m => m.Parent).HasForeignKey(m => m.IdParent);
		}
	}
}