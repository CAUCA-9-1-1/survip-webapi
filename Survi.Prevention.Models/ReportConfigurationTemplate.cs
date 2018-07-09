using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
	public class ReportConfigurationTemplate : BaseModel
	{
		public string Data { get; set; }
		public string Name { get; set; } = "";
	}
}
