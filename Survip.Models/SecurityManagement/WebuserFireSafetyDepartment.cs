using System;
using Survip.Models.Base;

namespace Survip.Models.SecurityManagement
{
  public class WebuserFireSafetyDepartment : BaseModel
  {
    public Guid IdWebuser { get; set; }
    public Guid IdFireSafetyDepartment { get; set; }
  }
}
