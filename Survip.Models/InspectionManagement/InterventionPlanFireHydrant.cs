using System;
using Survip.Models.Base;

namespace Survip.Models.InspectionManagement
{
  public class InterventionPlanFireHydrant : BaseModel
  {
    public DateTime DeletedOn { get; set; }

    public Guid IdInterventionPlan { get; set; }
    public Guid IdFireHydrant { get; set; }
  }
}
