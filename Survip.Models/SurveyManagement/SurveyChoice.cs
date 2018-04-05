using System;
using Survip.Models.Base;

namespace Survip.Models.SurveyManagement
{
  public class SurveyChoice : BaseModel
  {
    public int Sequence { get; set; }

    public Guid IdSurveyQuestion { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdSurveyQuestionNext { get; set; }
  }
}
