using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class State : BaseModel
  {
    public string AnsiCode { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdCountry { get; set; }
  }
}
