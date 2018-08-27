using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingCourseMapping : EntityMappingConfiguration<InspectionBuildingCourse>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingCourse> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Firestation).WithMany().HasForeignKey(m => m.IdFirestation);
			b.HasMany(m => m.Lanes).WithOne(m => m.Course).HasForeignKey(m => m.IdBuildingCourse).OnDelete(DeleteBehavior.Cascade);
		}
	}
}