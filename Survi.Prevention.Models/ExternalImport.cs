using System;

namespace Survi.Prevention.Models
{
  public class ExternalImport
  {
    public Guid IdExternalImport { get; set; }
    public Guid InternalId { get; set; }
    public string InternalTable { get; set; }
    public string ExternalId { get; set; }
    public string ExternalTable { get; set; }
    public DateTime ImportedOn { get; set; }
  }
}