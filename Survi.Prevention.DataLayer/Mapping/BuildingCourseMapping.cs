using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingCourseMapping : BaseImportedModelMapping<BuildingCourse>
	{
		public override void Map(EntityTypeBuilder<BuildingCourse> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Firestation).WithMany().HasForeignKey(m => m.IdFirestation);
			b.HasMany(m => m.Lanes).WithOne(m => m.Course).HasForeignKey(m => m.IdBuildingCourse);
		}
	}
}