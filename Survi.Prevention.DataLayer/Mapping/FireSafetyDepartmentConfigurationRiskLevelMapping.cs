using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentConfigurationRiskLevelMapping : EntityMappingConfiguration<FireSafetyDepartmentInspectionConfigurationRiskLevel>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDepartmentInspectionConfigurationRiskLevel> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);
		}
	}
}