using System;
using Survip.Models.Base;

namespace Survip.Models.Buildings
{
  public class RiskLevel : BaseModel
  {
    public int Sequence { get; set; }
    public int Code { get; set; }
    public string Color { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
