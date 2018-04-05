using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class Region : BaseModel
  {
    public string Code { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdState { get; set; }
  }
}
