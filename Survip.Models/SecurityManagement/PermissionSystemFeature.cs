using System;
using Survip.Models.Base;

namespace Survip.Models.SecurityManagement
{
  public class PermissionSystemFeature : BaseModel
  {
    public string FeatureName { get; set; }
    public string Description { get; set; }
    public string DefaultValue { get; set; }
    public Guid IdPermissionSystem { get; set; }
  }
}
