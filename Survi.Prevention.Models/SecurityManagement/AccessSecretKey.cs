using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SecurityManagement
{
  public class AccessSecretKey : BaseModel
  {
    public string ApplicationName { get; set; }
    public string RandomKey { get; set; }
    public string SecretKey { get; set; }
  }
}
