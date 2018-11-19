using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingDetailService : BaseCrudService<InspectionBuildingDetail>
	{
		public InspectionBuildingDetailService(ManagementContext context) : base(context)
		{
		}

		public InspectionBuildingDetail GetByIdBuilding(Guid idBuilding)
		{
			var detail = Context.InspectionBuildingDetails.AsNoTracking()
				             .SingleOrDefault(d => d.IdBuilding == idBuilding) ?? GenerateNewDetail(idBuilding);

			return detail;
		}

		private InspectionBuildingDetail GenerateNewDetail(Guid idBuilding)
		{
			var detail = new InspectionBuildingDetail { IdBuilding = idBuilding };
			Context.Add(detail);
			Context.SaveChanges();
			return detail;
		}

		public override InspectionBuildingDetail Get(Guid id)
		{
			return Context.InspectionBuildingDetails.AsNoTracking()
				.SingleOrDefault(detail => detail.Id == id);
		}

		public override List<InspectionBuildingDetail> GetList()
		{
			return Enumerable.Empty<InspectionBuildingDetail>().ToList();
		}
	}
}