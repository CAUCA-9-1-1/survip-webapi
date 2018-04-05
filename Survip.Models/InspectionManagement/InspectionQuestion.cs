using System;
using Survip.Models.Base;

namespace Survip.Models.InspectionManagement
{
  public class InspectionQuestion : BaseModel
  {
    public Guid IdInspectionAnswer { get; set; }
    public Guid IdSurveyQuestion { get; set; }
    public Guid IdSurveyChoice { get; set; }
    public string Answer { get; set; }
  }
}
