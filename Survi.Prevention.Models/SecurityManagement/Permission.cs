using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SecurityManagement
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
