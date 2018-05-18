using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

	    public override List<BuildingAnomaly> GetList()
	    {
		    throw new NotImplementedException();
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
	}
}
