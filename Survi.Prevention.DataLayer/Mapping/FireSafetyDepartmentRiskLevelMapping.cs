using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class FireSafetyDepartmentConfigurationMapping : EntityMappingConfiguration<FireSafetyDepartmentInspectionConfiguration>
	{
		public override void Map(EntityTypeBuilder<FireSafetyDepartmentInspectionConfiguration> b)
		{
			b.HasKey(m => m.Id);

			b.HasMany(m => m.RiskLevels).WithOne(m => m.Configuration).HasForeignKey(m => m.IdFireSafetyDepartmentInspectionConfiguration);
			b.HasOne(m => m.Survey).WithMany().HasForeignKey(m => m.IdSurvey);
        }
	}
}