using System;
using Survip.Models.Base;

namespace Survip.Models.InspectionManagement
{
  public class InterventionPlanCourse : BaseModel
  {
    public Guid IdInterventionPlan { get; set; }
    public Guid IdFirestation { get; set; }
  }
}
