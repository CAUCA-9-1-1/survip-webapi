using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class CityTypeMapping : EntityMappingConfiguration<CityType>
	{
		public override void Map(EntityTypeBuilder<CityType> b)
		{
			b.HasKey(m => m.Id);
			b.Property(m => m.CreatedOn).IsRequired();
			b.Property(m => m.IsActive).IsRequired();
		}
	}
}