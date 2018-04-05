using Survip.Models.Base;

namespace Survip.Models
{
  public class AccessSecretkey : BaseModel
  {
    public string ApplicationName { get; set; }
    public string RandomKey { get; set; }
    public string SecretKey { get; set; }
  }
}
