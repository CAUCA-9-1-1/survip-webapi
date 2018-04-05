using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
  public class AccessSecretkey : BaseModel
  {
    public string ApplicationName { get; set; }
    public string RandomKey { get; set; }
    public string SecretKey { get; set; }
  }
}
