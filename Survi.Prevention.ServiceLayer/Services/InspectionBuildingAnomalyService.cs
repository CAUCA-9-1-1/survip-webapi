using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingAnomalyService : BaseCrudService<InspectionBuildingAnomaly>
	{
		public InspectionBuildingAnomalyService(ManagementContext context) : base(context)
		{
		}

		public override InspectionBuildingAnomaly Get(Guid id)
		{
			return Context.InspectionBuildingAnomalies.AsNoTracking()
				.FirstOrDefault(anomaly => anomaly.Id == id);
		}

		public List<InspectionBuildingAnomaly> GetList(Guid idBuilding)
		{
			var value = Context.InspectionBuildingAnomalies
				.Where(a => a.IsActive && a.IdBuilding == idBuilding)
				.Include(a => a.Pictures)
				.ThenInclude(p => p.Picture)
				.ToList();

			return value;
		}

		public List<InspectionBuildingAnomalyThemeForList> GetListForWeb(Guid idBuilding)
		{
			var query =
				from anomaly in Context.InspectionBuildingAnomalies.AsNoTracking()
				where anomaly.IdBuilding == idBuilding && anomaly.IsActive
				select new BuildingAnomalyForList
				{
					Id = anomaly.Id,
					Theme = anomaly.Theme,
					Notes = anomaly.Notes
				};

			var result = query.ToList();

			var finalResult =
				from anomaly in result
				group anomaly by anomaly.Theme
				into theme
				select new InspectionBuildingAnomalyThemeForList
				{
					Theme = theme.Key,
					Anomalies = theme.ToList()
				};

			return finalResult.ToList();
		}

		public List<string> GetThemes()
		{
			var query =
				from anomaly in Context.InspectionBuildingAnomalies.AsNoTracking()
				where anomaly.IsActive
				select anomaly.Theme;

			return query.Distinct().ToList();
		}

		public virtual Guid AddOrUpdatePicture(InspectionBuildingAnomalyPicture entity)
		{
			var isExistRecord = Context.InspectionBuildingAnomalyPictures.Any(c => c.Id == entity.Id);

			if (isExistRecord)
				Context.InspectionBuildingAnomalyPictures.Update(entity);
			else
				Context.InspectionBuildingAnomalyPictures.Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Delete(Guid id)
		{
			var entity = Context.InspectionBuildingAnomalies.Find(id);
			if (entity != null)
			{
				DeleteAnomalyPictures(entity.Id);
				Remove(id);
				Context.SaveChanges();
				return true;
			}

			return false;
		}

		private void DeleteAnomalyPictures(Guid idBuildingAnomaly)
		{
			var anomalyPictures = Context.InspectionBuildingAnomalyPictures
									.Where(bap => bap.IdBuildingAnomaly == idBuildingAnomaly)
									.ToList();
			anomalyPictures.ForEach(pic =>
			{
				pic.IsActive = false;
				var picture = Context.InspectionPictures.Find(pic.IdPicture);
				if (picture != null)
					picture.IsActive = false;
			});
		}
	}
}
