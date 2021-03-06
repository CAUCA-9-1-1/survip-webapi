using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings.Base
{
	public abstract class BaseBuildingDetail<TBuilding, TPicture> : BaseImportedModel 
		where TBuilding : IBaseBuilding
        where TPicture : BasePicture
	{
		public string AdditionalInformation { get; set; } = "";
		public decimal Height { get; set; }
		public int EstimatedWaterFlow { get; set; }
		public GarageType GarageType { get; set; } = GarageType.No;
		public DateTime? RevisedOn { get; set; }
		public DateTime? ApprovedOn { get; set; }

		public Guid IdBuilding { get; set; }
		public Guid? IdUnitOfMeasureHeight { get; set; }
		public Guid? IdUnitOfMeasureEstimatedWaterFlow { get; set; }
		public Guid? IdConstructionType { get; set; }
		public Guid? IdConstructionFireResistanceType { get; set; }

		public Guid? IdPicturePlan { get; set; }
		public Guid? IdRoofType { get; set; }
		public Guid? IdRoofMaterialType { get; set; }
		public Guid? IdBuildingType { get; set; }
		public Guid? IdBuildingSidingType { get; set; }

		public UnitOfMeasure HeightUnitOfMeasure { get; set; }
		public UnitOfMeasure EstimatedWaterFlowUnitOfMeasure { get; set; }
		public ConstructionType ConstructionType { get; set; }
		public ConstructionFireResistanceType FireResistanceType { get; set; }
		public RoofType RoofType { get; set; }
		public RoofMaterialType RoofMaterialType { get; set; }
		public SidingType SidingType { get; set; }
		public BuildingType BuildingType { get; set; }
		public TBuilding Building { get; set; }

		public TPicture PlanPicture { get; set; }
	}
}