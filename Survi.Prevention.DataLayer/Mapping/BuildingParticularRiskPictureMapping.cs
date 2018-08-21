using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingParticularRiskPictureMapping : EntityMappingConfiguration<BuildingParticularRiskPicture>
	{
		public override void Map(EntityTypeBuilder<BuildingParticularRiskPicture> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture);
		}
	}

	public class InspectionBuildingParticularRiskPictureMapping : EntityMappingConfiguration<InspectionBuildingParticularRiskPicture>
	{
		public override void Map(EntityTypeBuilder<InspectionBuildingParticularRiskPicture> b)
		{
			b.HasKey(m => m.Id);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture);
		}
	}
}