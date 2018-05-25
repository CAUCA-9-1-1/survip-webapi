using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentRiskLevelMapping : EntityMappingConfiguration<FireSafetyDepartmentRiskLevel>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDepartmentRiskLevel> b)
		{
			b.HasKey(m => m.Id);

            b.HasOne(m => m.RiskLevel).WithMany().HasForeignKey(m => m.IdRiskLevel);
			b.HasOne(m => m.Survey).WithMany().HasForeignKey(m => m.IdSurvey);
		}
	}
}