using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class FireSafetyDeparmentServing : BaseModel
  {
    public Guid IdFireSafetyDepartment { get; set; }
    public Guid IdCity { get; set; }
    public Guid IdSectorType { get; set; }
  }
}
