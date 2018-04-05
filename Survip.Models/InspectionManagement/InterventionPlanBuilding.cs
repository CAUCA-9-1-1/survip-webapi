using System;
using Survip.Models.Base;

namespace Survip.Models.InspectionManagement
{
  public class InterventionPlanBuilding : BaseModel
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

    public Guid IdBuilding { get; set; }
    public Guid IdUnitOfMeasureHeight { get; set; }
    public Guid IdUnitOfMeasureEstimatedWaterFlow { get; set; }
    public Guid IdConstructionType { get; set; }
    public Guid IdConstructionTypeForJoist { get; set; }
    public Guid IdAlarmPanelType { get; set; }
    public Guid IdPicture { get; set; }
  }
}
