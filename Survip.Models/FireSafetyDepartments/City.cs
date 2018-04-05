using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class City : BaseModel
  {
    public string Code { get; set; }
    public string Code3Letters { get; set; }
    public string EmailAddress { get; set; }

    public Guid IdBuilding { get; set; }
    public Guid IdCityType { get; set; }
    public Guid IdCounty { get; set; }
    public Guid IdLanguageContentName { get; set; }
  }
}
