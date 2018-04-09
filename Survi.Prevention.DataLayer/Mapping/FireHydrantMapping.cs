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
			b.ToTable("tbl_fire_hydrant")
				.HasKey(m => m.Id);

			b.Property(m => m.Id).HasColumnName("id_fire_hydrant");
			b.Property(m => m.IdLane).HasColumnName("id_lane");
			b.Property(m => m.IdIntersection).HasColumnName("id_intersection");
			b.Property(m => m.IdFireHydrantType).HasColumnName("id_fire_hydrant_type");
			b.Property(m => m.Coordinates).HasColumnName("coordinates");
			b.Property(m => m.Altitude).HasColumnName("altitude");
			b.Property(m => m.Number).HasColumnName("fire_hydrant_number").IsRequired().HasMaxLength(10);
			b.Property(m => m.IdOperatorTypeRate).HasColumnName("id_operator_type_rate").IsRequired();
			b.Property(m => m.RateFrom).HasColumnName("rate_from").IsRequired().HasMaxLength(5);
			b.Property(m => m.RateTo).HasColumnName("rate_to").IsRequired().HasMaxLength(5);
			b.Property(m => m.IdUnitOfMeasureRate).HasColumnName("id_unit_of_measure_rate").IsRequired();
			b.Property(m => m.IdOperatorTypePressure).HasColumnName("id_operator_type_pressure").IsRequired();
			b.Property(m => m.PressureFrom).HasColumnName("pressure_from").IsRequired().HasMaxLength(5);
			b.Property(m => m.PressureTo).HasColumnName("pressure_to").IsRequired().HasMaxLength(5);
			b.Property(m => m.IdUnitOfMeasurePressure).HasColumnName("id_unit_of_measure_pressure").IsRequired();
			b.Property(m => m.Color).HasColumnName("color").IsRequired().HasMaxLength(50);
			b.Property(m => m.Comments).HasColumnName("comments");
			b.Property(m => m.PhysicalPosition).HasColumnName("physical_position").HasMaxLength(50);
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();

			b.HasMany(m => m.Connections).WithOne(m => m.Hydrant).HasForeignKey(m => m.IdFireHydrant);

			b.HasOne(m => m.Lane).WithMany().HasForeignKey(m => m.IdLane);
			b.HasOne(m => m.Intersection).WithMany().HasForeignKey(m => m.IdIntersection);
			b.HasOne(m => m.HydrantType).WithMany().HasForeignKey(m => m.IdFireHydrantType);
			b.HasOne(m => m.RateOperatorType).WithMany().HasForeignKey(m => m.IdOperatorTypeRate);
			b.HasOne(m => m.PressureOperatorType).WithMany().HasForeignKey(m => m.IdOperatorTypePressure);
			b.HasOne(m => m.RateUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureRate);
			b.HasOne(m => m.PressureUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasurePressure);
		}
	}
}