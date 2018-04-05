using Survip.Models.Base;

namespace Survip.Models.SecurityManagement
{
  public class Webuser : BaseModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
