using System.Collections.Generic;

namespace Survi.Prevention.Models.Security
{
	public class User : Cause.SecurityManagement.Models.User
	{
		public ICollection<UserFireSafetyDepartment> UserFireSafetyDepartments { get; set; }
		public string PhoneNumber { get; set; }
	}
}
