using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class BuildingDetailMapping : BaseImportedModelMapping<BuildingDetail>
	{
		public override void Map(EntityTypeBuilder<BuildingDetail> b)
		{
			b.HasQueryFilter(m => m.IsActive);

			b.Property(m => m.AdditionalInformation).IsRequired();

			b.HasOne(m => m.HeightUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureHeight).HasConstraintName("fk_unit_of_measure_height");
			b.HasOne(m => m.EstimatedWaterFlowUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureEstimatedWaterFlow).HasConstraintName("fk_unit_of_measure_ewf");
			b.HasOne(m => m.ConstructionType).WithMany().HasForeignKey(m => m.IdConstructionType).HasConstraintName("fk_construction_type");
			b.HasOne(m => m.RoofType).WithMany().HasForeignKey(m => m.IdRoofType);
			b.HasOne(m => m.SidingType).WithMany().HasForeignKey(m => m.IdBuildingSidingType);
			b.HasOne(m => m.BuildingType).WithMany().HasForeignKey(m => m.IdBuildingType);
			b.HasOne(m => m.RoofMaterialType).WithMany().HasForeignKey(m => m.IdRoofMaterialType);
			b.HasOne(m => m.PlanPicture).WithMany().HasForeignKey(m => m.IdPicturePlan);
		}
	}
}