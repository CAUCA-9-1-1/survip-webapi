using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.InspectionManagement
{
  public class InterventionPlanFireHydrant : BaseModel
  {
    public DateTime DeletedOn { get; set; }

    public Guid IdInterventionPlan { get; set; }
    public Guid IdFireHydrant { get; set; }
  }
}
