using System;
using Survip.Models.Base;

namespace Survip.Models
{
  public class Picture : BaseModel
  {
    public bool Transfered { get; set; }
    public byte[] ActualPicture { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
