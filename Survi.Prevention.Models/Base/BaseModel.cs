using System;

namespace Survi.Prevention.Models.Base
{
  public abstract class BaseModel
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
  }
}
