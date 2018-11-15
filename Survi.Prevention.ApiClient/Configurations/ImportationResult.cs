using System.Collections.Generic;

namespace Survi.Prevention.ApiClient.Configurations
{
    public class ImportationResult
    {
        public bool HasBeenImported { get; set; }
        public string IdEntity { get; set; }
	    public string EntityName { get; set; }
	    public List<string> Messages { get; set; }
    }
}
