using System;
using System.Collections.Generic;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.DataLayer.InitialData
{
	internal class InitialUserGenerator
	{
		internal static IEnumerable<Webuser> GetInitialData()
		{
			yield return new Webuser
			{
				Username = "admin",
				Password = "EDDDFC93F0EBE76F4F79D9C83C298D1126F7F3A01259637AD028607D364FD247",
				CreatedOn = DateTime.Now,
				Attributes = new List<WebuserAttributes>
				{
					new WebuserAttributes { AttributeName = "last_name", AttributeValue = "Cauca"},
					new WebuserAttributes { AttributeName = "reset_password", AttributeValue = "false"},
					new WebuserAttributes { AttributeName = "first_name", AttributeValue = "Admin"},
				}
			};
		}
	}
}