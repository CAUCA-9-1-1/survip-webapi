using System;

namespace Survip.Models.SecurityManagement
{
  public class WebuserAttributes
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
  }
}
