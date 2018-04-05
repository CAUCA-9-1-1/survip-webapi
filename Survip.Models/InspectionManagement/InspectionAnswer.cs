using System;
using Survip.Models.Base;

namespace Survip.Models.InspectionManagement
{
  public class InspectionAnswer : BaseModel
  {
    public DateTime AnsweredOn { get; set; }
    public bool HasRefused { get; set; }
    public bool ReasonForRefusal { get; set; }
    public bool IsAbsent { get; set; }
    public bool IsSeasonal { get; set; }
    public bool IsVacant { get; set; }

    public Guid IdInspection { get; set; }
    public Guid IdWebUser { get; set; }
  }
}
