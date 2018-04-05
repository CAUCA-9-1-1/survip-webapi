using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
  public class Survey : BaseModel
  {
    public int SurveyType { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
