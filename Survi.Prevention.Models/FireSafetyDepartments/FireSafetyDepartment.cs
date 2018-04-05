using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class FireSafetyDepartment : BaseModel
  {
    public string Language { get; set; }
    public Guid IdCounty { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
