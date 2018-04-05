using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class Country : BaseModel
  {
    public string CodeAlpha2 { get; set; }
    public string CodeAlpha3 { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
