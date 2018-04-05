using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class Lane : BaseModel
  {
    public bool IsValid { get; set; }

    public string PublicLaneCode { get; set; }
    public string GenericCode { get; set; }
    public Guid IdLanguageContentName { get; set; }
    public Guid IdCity { get; set; }
  }
}
