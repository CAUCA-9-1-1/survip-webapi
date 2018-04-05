using System;
using Survip.Models.Base;

namespace Survip.Models.SecurityManagement
{
  public class PermissionObject : BaseModel
  {
    public string ObjectTable { get; set; }
    public string GenericId { get; set; }
    public bool IsGroup { get; set; }
    public string GroupName { get; set; }

    public Guid IdPermissionSystem { get; set; }
    public Guid IdPermissionObjectParent { get; set; }
  }
}
