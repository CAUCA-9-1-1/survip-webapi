using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SecurityManagement
{
  public class Webuser : BaseModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
