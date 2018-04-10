using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class WebuserAttributeMapping : EntityMappingConfiguration<WebuserAttributes>
	{
		public override void Map(EntityTypeBuilder<WebuserAttributes> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.AttributeName).HasMaxLength(50).IsRequired();
			b.Property(m => m.AttributeValue).HasMaxLength(50).IsRequired();
		}
	}
}