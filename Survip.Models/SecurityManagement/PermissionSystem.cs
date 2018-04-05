using System;

namespace Survip.Models.SecurityManagement
{
  public class PermissionSystem
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
  }
}
