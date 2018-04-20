using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FirestationService : BaseCrudService<Firestation>
	{
		public FirestationService(ManagementContext context) : base(context)
		{
		}

		public override Firestation Get(Guid id)
		{
			var result = Context.Firestations
				.First(s => s.Id == id);

			return result;
		}

		public override List<Firestation> GetList()
		{
			var result = Context.Firestations
				.ToList();

			return result;
		}
	}
}