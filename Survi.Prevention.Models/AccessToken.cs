using System;

namespace Survi.Prevention.Models
{
  public class AccessToken
  {
    public Guid Id { get; set; }
    public string ActualAccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ExpiresIn { get; set; }
  }
}
