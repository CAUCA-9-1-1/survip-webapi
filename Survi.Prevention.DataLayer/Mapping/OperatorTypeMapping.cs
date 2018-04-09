using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireHydrants;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class OperatorTypeMapping : EntityMappingConfiguration<OperatorType>
	{
		public override void Map(EntityTypeBuilder<OperatorType> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.Symbol).HasMaxLength(3).IsRequired();
		}
	}
}