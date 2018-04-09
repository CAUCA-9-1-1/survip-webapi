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
			b.ToTable("tbl_unit_of_measure").HasKey(m => m.Id);

			b.Property(m => m.Abbreviation).HasColumnName("abbreviation").HasMaxLength(5).IsRequired();
			b.Property(m => m.MeasureType).HasColumnName("type").HasMaxLength(20).IsRequired();
			b.Property(m => m.Id).HasColumnName("id_operator_type");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
		}
	}
}