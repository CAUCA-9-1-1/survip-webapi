using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
  public class County : BaseModel
  {
    public Guid IdLanguageContentName { get; set; }
    public Guid IdRegion { get; set; }
    public Guid IdState { get; set; }
  }
}
