using System;
using Survip.Models.Base;

namespace Survip.Models.Buildings
{
  public class HazardousMaterial : BaseModel
  {
    public string Number { get; set; }
    public string GuideNumber { get; set; }
    public bool ReactToWater { get; set; }
    public bool ToxicInhalationHazard { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
