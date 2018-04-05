using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class Country : BaseModel
  {
    public string CodeAlpha2 { get; set; }
    public string CodeAlpha3 { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
