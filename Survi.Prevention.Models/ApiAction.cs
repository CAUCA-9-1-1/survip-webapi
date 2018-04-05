using System;

namespace Survi.Prevention.Models
{
  public class ApiAction
  {
    public Guid Id { get; set; }
    public string Method { get; set; }
    public string Params { get; set; }
    public DateTime ActionTime { get; set; }
    public string ActionObject { get; set; }
    public Guid IdActionObject { get; set; }
    public string ActionIp { get; set; }
  }
}