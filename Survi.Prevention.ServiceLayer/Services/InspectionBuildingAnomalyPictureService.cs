using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingAnomalyPictureService : BaseCrudService<BuildingAnomalyPicture>
	{
		public InspectionBuildingAnomalyPictureService(ManagementContext context) : base(context)
		{
		}

		public override BuildingAnomalyPicture Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public override List<BuildingAnomalyPicture> GetList()
		{
			throw new NotImplementedException();
		}

		public List<BuildingAnomalyPicture> GetAnomalyPictures(Guid idBuildingAnomaly)
		{
			return Context.BuildingAnomalyPictures.AsNoTracking()
				.Where(picture => picture.IdBuildingAnomaly == idBuildingAnomaly)
				.ToList();
		}
	}
}