using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class FireSafetyDepartment : BaseModel
  {
    public string Language { get; set; }
    public Guid IdCounty { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
