using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.InspectionManagement
{
  public class InspectionQuestion : BaseModel
  {
    public Guid IdInspectionAnswer { get; set; }
    public Guid IdSurveyQuestion { get; set; }
    public Guid IdSurveyChoice { get; set; }
    public string Answer { get; set; }
  }
}
