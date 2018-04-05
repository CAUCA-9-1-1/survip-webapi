using System;
using Survip.Models.Base;

namespace Survip.Models.SurveyManagement
{
  public class SurveyQuestion : BaseModel
  {
    public int Sequence { get; set; }
    public int QuestionType { get; set; }

    public Guid IdSurvey { get; set; }
    public Guid IdLanguageContentTitle { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdSurveyQuestionNext { get; set; }
  }
}
