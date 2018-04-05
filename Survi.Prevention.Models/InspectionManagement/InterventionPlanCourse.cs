using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.InspectionManagement
{
  public class InterventionPlanCourse : BaseModel
  {
    public Guid IdInterventionPlan { get; set; }
    public Guid IdFirestation { get; set; }
  }
}
