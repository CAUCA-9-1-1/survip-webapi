using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class State : BaseModel
  {
    public string AnsiCode { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdCountry { get; set; }
  }
}
