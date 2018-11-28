using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InspectionBuildingParticularRiskPictureMapping : BaseImportedModelMapping<InspectionBuildingParticularRiskPicture>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingParticularRiskPicture> b)
		{
			b.HasQueryFilter(m => m.IsActive);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture)
				.OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull);
		}
	}
}