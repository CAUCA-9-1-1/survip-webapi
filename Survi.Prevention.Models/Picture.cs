using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
  public class Picture : BaseModel
  {
    public bool Transfered { get; set; }
    public byte[] ActualPicture { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
