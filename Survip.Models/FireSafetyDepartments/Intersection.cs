using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class Intersection : BaseModel
  {
    public object Coordinates { get; set; }

    public Guid IdLane { get; set; }
    public Guid IdLaneTransversal { get; set; }
    public Guid IdFireSector { get; set; }
    public Guid IdJawsSector { get; set; }
    public Guid IdMutualAidSector { get; set; }
    public Guid IdRescueSector { get; set; }
    public Guid IdFireSubSector { get; set; }
  }
}
