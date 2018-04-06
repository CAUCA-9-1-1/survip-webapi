using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InterventionFormBuilding : BaseModel
	{
		public string AdditionalInformation { get; set; }
		public string Height { get; set; }
		public int EstimatedWaterFlow { get; set; }
		public string SprinklerType { get; set; }
		public string SprinklerFloor { get; set; }
		public string SprinklerWall { get; set; }
		public string SprinklerSector { get; set; }
		public string PipelineLocation { get; set; }
		public string AlarmPanelFloor { get; set; }
		public string AlarmPanelWall { get; set; }
		public string AlarmPanelSector { get; set; }
		public string BuildingPlanNumber { get; set; }
		public bool IsParent { get; set; }

		public Guid IdInterventionForm { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid? IdUnitOfMeasureHeight { get; set; }
		public Guid? IdUnitOfMeasureEstimatedWaterFlow { get; set; }
		public Guid? IdConstructionType { get; set; }
		public Guid? IdConstructionTypeForJoist { get; set; }
		public Guid? IdAlarmPanelType { get; set; }
		public Guid? IdPicture { get; set; }		

		public InterventionForm Form { get; set; }
		public Building Building { get; set; }
		public UnitOfMeasure HeightUnitOfMeasure { get; set; }
		public UnitOfMeasure EstimatedWaterFlowUnitOfMeasure { get; set; }
		public ConstructionType ConstructionType { get; set; }
		public ConstructionType JoistConstructionType { get; set; }
		public AlarmPanelType AlarmPanelType { get; set; }
		public Picture Picture { get; set; }
	}
}
