using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingCourseMapping : EntityMappingConfiguration<BuildingCourse>
	{
		public override void Map(EntityTypeBuilder<BuildingCourse> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Firestation).WithMany().HasForeignKey(m => m.IdFirestation);
			b.HasMany(m => m.Lanes).WithOne(m => m.Course).HasForeignKey(m => m.IdBuildingCourse);
		}
	}
}