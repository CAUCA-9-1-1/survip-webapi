using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
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
