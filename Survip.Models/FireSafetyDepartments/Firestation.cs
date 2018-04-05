using System;
using Survip.Models.Base;

namespace Survip.Models.FireSafetyDepartments
{
  public class Firestation : BaseModel
  {
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string FaxNumber { get; set; }
    public string Email { get; set; }
    public Guid IdBuilding { get; set; }
  }
}
