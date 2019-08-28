using System;
using System.Collections.Generic;
using System.Text;
using Cause.SecurityManagement.Models;

namespace Survi.Prevention.Models.Security
{
	public class UserFireSafetyDepartment : BaseModel
	{
		public string FireSafetyDepartmentId { get; set; }
		public Guid UserId { get; set; }
	}
}