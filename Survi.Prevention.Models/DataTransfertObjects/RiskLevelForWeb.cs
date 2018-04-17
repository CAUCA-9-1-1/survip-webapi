using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class RiskLevelForWeb
    {
		public Guid Id { get; set; }
	    public int Sequence { get; set; }
	    public int Code { get; set; }
	    public string Color { get; set; }
		public string Name { get; set; }
	}
}
