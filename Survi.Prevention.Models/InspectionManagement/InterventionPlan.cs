using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.InspectionManagement
{
  public class InterventionPlan : BaseModel
  {
    public string Name { get; set; }
    public string Number { get; set; }
    public string OtherInformation { get; set; }
    public DateTime RevisedOn { get; set; }
    public DateTime ApprovedOn { get; set; }
    public Guid IdLaneTransversal { get; set; }
    public Guid IdPictureSitePlan { get; set; }
  }
}
