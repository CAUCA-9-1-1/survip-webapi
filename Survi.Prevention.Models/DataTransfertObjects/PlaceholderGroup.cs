using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class PlaceholderGroup
    {
		public string Name { get; set; }
		public string Tag { get; set; }
		public List<string> Placeholders { get; set; }
    }
}
