using System;
using System.Collections.Generic;
using System.Text;
using Cause.SecurityManagement.Models;

namespace Survi.Prevention.Models.Security
{
	public class User : Cause.SecurityManagement.Models.User
	{
		public ICollection<UserFireSafetyDepartment> UserFireSafetyDepartments { get; set; }
	}
}
