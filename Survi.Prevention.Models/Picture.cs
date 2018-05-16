using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
	public class Picture : BaseModel
	{
		public byte[] Data { get; set; }
		public string Name { get; set; } = "";
	}
}
