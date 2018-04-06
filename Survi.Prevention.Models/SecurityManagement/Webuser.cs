using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SecurityManagement
{
	public class Webuser : BaseModel
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public ICollection<WebuserAttributes> Attributes { get; set; }
		public ICollection<WebuserFireSafetyDepartment> FireSafetyDerpartments { get; set; }
	}
}
