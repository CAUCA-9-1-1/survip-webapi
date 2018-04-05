using System;
using Survip.Models.Base;

namespace Survip.Models.SurveyManagement
{
  public class Survey : BaseModel
  {
    public int SurveyType { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
