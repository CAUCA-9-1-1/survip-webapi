using System;
using Survip.Models.Base;

namespace Survip.Models.FireHydrants
{
  public class FireHydrant : BaseModel
  {
    public object Coordinates { get; set; }
    public decimal Altitude { get; set; }
    public string Number { get; set; }
    public string RateFrom { get; set; }
    public string RateTo { get; set; }
    public string PressureFrom { get; set; }
    public string PressureTo { get; set; }
    public string Color { get; set; }
    public string Comments { get; set; }
    public string PhysicalPosition { get; set; }

    public Guid IdIntersection { get; set; }
    public Guid IdFireHydrantType { get; set; }
    public Guid IdOperatorTypeRate { get; set; }
    public Guid IdUnitOfMeasureRate { get; set; }
    public Guid IdOperatorTypePressure { get; set; }
    public Guid IdUnitOfMeasurePressure { get; set; }
  }
}
