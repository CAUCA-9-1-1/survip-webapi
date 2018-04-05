using System;
using Survip.Models.Base;

namespace Survip.Models.SecurityManagement
{
  public class Permission : BaseModel
  {
    public string Comments { get; set; }
    public bool Access { get; set; }

    public Guid IdPermissionObject { get; set; }
    public Guid IdPermissionSystem { get; set; }
    public Guid IdPermissionSystemFeature { get; set; }
  }
}
