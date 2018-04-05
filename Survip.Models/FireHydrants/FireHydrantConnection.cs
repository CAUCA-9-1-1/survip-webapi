using System;
using Survip.Models.Base;

namespace Survip.Models.FireHydrants
{
  public class FireHydrantConnection : BaseModel
  {
    public decimal Diameter { get; set; }

    public Guid IdFireHydrant { get; set; }
    public Guid IdUnitOfMeasureDiameter { get; set; }
    public Guid IdFireHydrantConnectionType { get; set; }
  }
}
