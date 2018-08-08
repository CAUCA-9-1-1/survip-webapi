using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireHydrantMapping : EntityMappingConfiguration<FireHydrant>
	{
		public override void Map(EntityTypeBuilder<FireHydrant> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Number).IsRequired().HasMaxLength(10);
			b.Property(m => m.RateFrom).IsRequired().HasMaxLength(5);
			b.Property(m => m.RateTo).IsRequired().HasMaxLength(5);
			b.Property(m => m.PressureFrom).IsRequired().HasMaxLength(5);
			b.Property(m => m.PressureTo).IsRequired().HasMaxLength(5);
			b.Property(m => m.Color).IsRequired().HasMaxLength(50);
			b.Property(m => m.PhysicalPosition).HasMaxLength(50);
			b.Property(m => m.Coordinates).HasColumnType("geography");

			b.HasMany(m => m.Connections).WithOne(m => m.Hydrant).HasForeignKey(m => m.IdFireHydrant);
			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
			b.HasOne(m => m.Intersection).WithMany().HasForeignKey(m => m.IdIntersection);
			b.HasOne(m => m.HydrantType).WithMany().HasForeignKey(m => m.IdFireHydrantType);
			b.HasOne(m => m.RateOperatorType).WithMany().HasForeignKey(m => m.IdOperatorTypeRate);
			b.HasOne(m => m.PressureOperatorType).WithMany().HasForeignKey(m => m.IdOperatorTypePressure);
			b.HasOne(m => m.RateUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureRate);
			b.HasOne(m => m.PressureUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasurePressure);
			b.HasOne(m => m.City).WithMany().HasForeignKey(m => m.IdCity);
			b.Property(m => m.CivicNumber).HasMaxLength(5);

		}
	}
}