using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBatchService : BaseCrudService<Batch>
	{
		public InspectionBatchService(ManagementContext context) : base(context)
		{
		}

		public override Batch Get(Guid id)
		{
			var result = Context.Batches
				.First(s => s.Id == id);

			return result;
		}

		public override List<Batch> GetList()
		{
			var result = Context.Batches
				.ToList();

			return result;
		}
	}
}