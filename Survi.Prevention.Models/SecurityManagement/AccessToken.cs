using System;

namespace Survi.Prevention.Models.SecurityManagement
{
  public class AccessToken
  {
    public Guid Id { get; set; }
    public string TokenForAccess { get; set; }
    public string RefreshToken { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ExpiresIn { get; set; }
    public Guid IdWebuser { get; set; }
  }
}
