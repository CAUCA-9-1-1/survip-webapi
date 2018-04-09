using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survi.Prevention.DataLayer.Mapping.Base;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.DataLayer.Mapping
{
	public class InterventionFormBuildingMapping : EntityMappingConfiguration<InterventionFormBuilding>
	{
		public override void Map(EntityTypeBuilder<InterventionFormBuilding> b)
		{
			b.HasKey(m => m.Id);

			b.Property(m => m.AdditionalInformation).IsRequired();
			b.Property(m => m.SprinklerFloor).HasMaxLength(50).IsRequired();
			b.Property(m => m.SprinklerSector).HasMaxLength(50).IsRequired();
			b.Property(m => m.SprinklerType).HasMaxLength(50).IsRequired();
			b.Property(m => m.SprinklerWall).HasMaxLength(50).IsRequired();
			b.Property(m => m.PipelineLocation).HasMaxLength(200).IsRequired();
			b.Property(m => m.AlarmPanelFloor).HasMaxLength(50).IsRequired();
			b.Property(m => m.AlarmPanelWall).HasMaxLength(50).IsRequired();
			b.Property(m => m.AlarmPanelSector).HasMaxLength(50).IsRequired();
			b.Property(m => m.BuildingPlanNumber).HasMaxLength(50).IsRequired();

			b.HasOne(m => m.Building).WithMany().HasForeignKey(m => m.IdBuilding);
			b.HasOne(m => m.HeightUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureHeight).HasConstraintName("fk_unit_of_measure_height");
			b.HasOne(m => m.EstimatedWaterFlowUnitOfMeasure).WithMany().HasForeignKey(m => m.IdUnitOfMeasureEstimatedWaterFlow).HasConstraintName("fk_unit_of_measure_ewf");
			b.HasOne(m => m.ConstructionType).WithMany().HasForeignKey(m => m.IdConstructionType).HasConstraintName("fk_construction_type");
			b.HasOne(m => m.JoistConstructionType).WithMany().HasForeignKey(m => m.IdConstructionTypeForJoist).HasConstraintName("fk_joist_construction_type");
			b.HasOne(m => m.AlarmPanelType).WithMany().HasForeignKey(m => m.IdAlarmPanelType);
			b.HasOne(m => m.Picture).WithMany().HasForeignKey(m => m.IdPicture);
		}
	}
}