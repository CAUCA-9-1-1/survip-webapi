using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingAnomalyPictureMapping : EntityMappingConfiguration<InspectionBuildingAnomalyPicture>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingAnomalyPicture> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture).OnDelete(DeleteBehavior.Cascade);
		}
	}
}