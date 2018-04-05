using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class Region : BaseModel
  {
    public string Code { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdState { get; set; }
  }
}
