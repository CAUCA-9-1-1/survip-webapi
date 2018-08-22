using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class WebuserFireSafetyDepartmentMapping : EntityMappingConfiguration<WebuserFireSafetyDepartment>
	{
		public override void Map(EntityTypeBuilder<WebuserFireSafetyDepartment> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.FireSafetyDepartment)
				.WithMany().HasForeignKey(m => m.IdFireSafetyDepartment);
		}
	}
}