using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentCityServingMapping : EntityMappingConfiguration<FireSafetyDepartmentCityServing>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDepartmentCityServing> b)
		{
			b.HasKey(m => m.Id);
		}
	}
}