using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingCourseMapping : BaseImportedModelMapping<InspectionBuildingCourse>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingCourse> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Firestation).WithMany().HasForeignKey(m => m.IdFirestation);
			b.HasMany(m => m.Lanes).WithOne(m => m.Course).HasForeignKey(m => m.IdBuildingCourse).OnDelete(DeleteBehavior.Cascade);
		}
	}
}