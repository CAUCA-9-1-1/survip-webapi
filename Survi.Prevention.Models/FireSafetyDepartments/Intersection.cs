using System;
using NpgsqlTypes;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class Intersection : BaseModel
  {
    public PostgisGeometry Coordinates { get; set; }

    public Guid IdLane { get; set; }
    public Guid IdLaneTransversal { get; set; }
    public Guid IdFireSector { get; set; }
    public Guid IdJawsSector { get; set; }
    public Guid IdMutualAidSector { get; set; }
    public Guid IdRescueSector { get; set; }
    public Guid IdFireSubSector { get; set; }
  }
}
