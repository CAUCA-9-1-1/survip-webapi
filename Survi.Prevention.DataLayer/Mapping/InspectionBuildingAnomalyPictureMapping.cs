using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingAnomalyPictureMapping : BaseImportedModelMapping<InspectionBuildingAnomalyPicture>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingAnomalyPicture> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture)
				.OnDelete(DeleteBehavior.SetNull);
		}
	}
}