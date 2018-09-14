using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class PlaceholderGroup
    {
		public string Name { get; set; }
		public string Tag { get; set; }
	    public List<Placeholder> Placeholders { get; set; } = new List<Placeholder>();
    }

	public class Placeholder
	{
		public string Tag { get; set; }
		public string Name { get; set; }
	}
}
