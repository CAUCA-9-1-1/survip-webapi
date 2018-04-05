using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class FireSafetyDeparmentServing : BaseModel
  {
    public Guid IdFireSafetyDepartment { get; set; }
    public Guid IdCity { get; set; }
    public Guid IdSectorType { get; set; }
  }
}
