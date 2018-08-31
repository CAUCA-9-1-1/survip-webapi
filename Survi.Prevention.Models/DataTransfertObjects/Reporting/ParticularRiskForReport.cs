using System;

namespace Survi.Prevention.Models.DataTransfertObjects.Reporting
{
    public class ParticularRiskForReport : IDataTransferObjectWithId
    {
		public Guid Id { get; set; }
	    public bool IsWeakened { get; set; }
	    public bool HasOpening { get; set; }
	    public string Comments { get; set; } = "";
	    public string Wall { get; set; }
	    public string Sector { get; set; }
	    public string Dimension { get; set; } = "";
	    public string TypeName { get; set; }
    }
}
