using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
  public class RiskLevel : BaseModel
  {
    public int Sequence { get; set; }
    public int Code { get; set; }
    public string Color { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
