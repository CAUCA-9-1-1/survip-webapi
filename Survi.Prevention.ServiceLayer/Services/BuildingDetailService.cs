using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingDetailService : BaseCrudService<BuildingDetail>
	{
		public BuildingDetailService(ManagementContext context) : base(context)
		{
		}

		public BuildingDetail GetByIdBuilding(Guid idBuilding)
		{
			var detail = Context.BuildingDetails.AsNoTracking()
				.SingleOrDefault(d => d.IdBuilding == idBuilding) ?? GenerateNewDetail(idBuilding);

			return detail;
		}

		private BuildingDetail GenerateNewDetail(Guid idBuilding)
		{
			var detail = new BuildingDetail { IdBuilding = idBuilding };
			Context.Add(detail);
			Context.SaveChanges();
			return detail;
		}

		public override BuildingDetail Get(Guid id)
		{
			return Context.BuildingDetails.AsNoTracking()
				.SingleOrDefault(detail => detail.Id == id);
		}

		public override List<BuildingDetail> GetList()
		{
			return Enumerable.Empty<BuildingDetail>().ToList();
		}
	}
}