using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InterventionFormCourseMapping : EntityMappingConfiguration<InterventionFormCourse>
	{
		public override void Map(EntityTypeBuilder<InterventionFormCourse> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Firestation).WithMany().HasForeignKey(m => m.IdFirestation);
			b.HasMany(m => m.Lanes).WithOne(m => m.Course).HasForeignKey(m => m.IdInterventionFormCourse);
		}
	}
}