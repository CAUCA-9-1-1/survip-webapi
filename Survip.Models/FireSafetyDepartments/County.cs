using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class County : BaseModel
  {
    public Guid IdLanguageContentName { get; set; }
    public Guid IdRegion { get; set; }
    public Guid IdState { get; set; }
  }
}
