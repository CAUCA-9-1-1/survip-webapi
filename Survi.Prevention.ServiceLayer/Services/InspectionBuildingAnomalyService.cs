﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class InspectionBuildingAnomalyService : BaseCrudService<BuildingAnomaly>
    {
	    public InspectionBuildingAnomalyService(ManagementContext context) : base(context)
	    {
	    }

	    public override BuildingAnomaly Get(Guid id)
	    {
		    return Context.BuildingAnomalies.AsNoTracking()
			    .FirstOrDefault(anomaly => anomaly.Id == id);
	    }

	    public List<BuildingAnomaly> GetList(Guid idBuilding)
	    {
		    return Context.BuildingAnomalies
			    .Where(a => a.IsActive && a.IdBuilding == idBuilding)
			    .Include(a => a.Pictures)
			    .ThenInclude(p => p.Picture)
			    .ToList();
	    }
	    
	    public List<InspectionBuildingAnomalyThemeForList> GetListForWeb(Guid idBuilding)
	    {
		    var query =
			    from anomaly in Context.BuildingAnomalies.AsNoTracking()
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
				from anomaly in Context.BuildingAnomalies.AsNoTracking()
				where anomaly.IsActive
				select anomaly.Theme;

			return query.Distinct().ToList();
		}

	    public virtual Guid AddOrUpdatePicture(BuildingAnomalyPicture entity)
	    {
		    var isExistRecord = Context.BuildingAnomalyPictures.Any(c => c.Id == entity.Id);

		    if (isExistRecord)
			    Context.BuildingAnomalyPictures.Update(entity);
		    else
			    Context.BuildingAnomalyPictures.Add(entity);

		    Context.SaveChanges();
		    return entity.Id;
	    }

	    public virtual bool Delete(Guid id)
	    {
		    var entity = Context.BuildingAnomalies.Find(id);
		    if(entity != null){
				DeleteAnomalyPictures(entity.Id);
			    Remove(id);
			    Context.SaveChanges();
			    return true;
		    }
	
			return false;
	    }

	    private void DeleteAnomalyPictures(Guid idBuildingAnomaly)
	    {
		    var anomalyPictures = Context.BuildingAnomalyPictures
									.Where(bap => bap.IdBuildingAnomaly == idBuildingAnomaly)
									.ToList();
		    anomalyPictures.ForEach(pic =>
		    {
			    pic.IsActive = false;
			    var picture = Context.Pictures.Find(pic.IdPicture);
			    picture.IsActive = false;
		    });
	    }
	}
}
