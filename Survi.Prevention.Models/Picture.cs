using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
  public class Picture : BaseModel
  {
    public byte[] ActualPicture { get; set; }
    public string Name { get; set; }
  }
}
