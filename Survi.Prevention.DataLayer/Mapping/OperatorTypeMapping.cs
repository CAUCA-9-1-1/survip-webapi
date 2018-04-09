using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class OperatorTypeMapping : EntityMappingConfiguration<OperatorType>
	{
		public override void Map(EntityTypeBuilder<OperatorType> b)
		{
			b.ToTable("tbl_operator_type").HasKey(m => m.Id);

			b.Property(m => m.Symbol).HasColumnName("symbol").HasMaxLength(3).IsRequired();
			b.Property(m => m.Id).HasColumnName("id_operator_type");
			b.Property(m => m.CreatedOn).HasColumnName("created_on").IsRequired();
			b.Property(m => m.IsActive).HasColumnName("is_active").IsRequired();
		}
	}
}