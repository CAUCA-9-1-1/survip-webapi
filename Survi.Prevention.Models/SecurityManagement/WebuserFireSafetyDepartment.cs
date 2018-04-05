using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SecurityManagement
{
  public class WebuserFireSafetyDepartment : BaseModel
  {
    public Guid IdWebuser { get; set; }
    public Guid IdFireSafetyDepartment { get; set; }
  }
}
