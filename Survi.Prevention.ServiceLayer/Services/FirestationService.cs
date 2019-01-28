using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FirestationService 
	    : BaseCrudServiceWithImportation<Firestation, ApiClient.DataTransferObjects.Firestation>
	{
	    public FirestationService(
	        IManagementContext context, 
	        IEntityConverter<ApiClient.DataTransferObjects.Firestation, Firestation> converter) 
	        : base(context, converter)
	    {
	    }

        public override Firestation Get(Guid id)
		{
			var result = Context.Firestations
				.First(s => s.Id == id);

			return result;
		}

        public List<Firestation> GetList(List<Guid> idFireSafetyDepartments)
		{
            var query =
                from firestation in Context.Firestations
                where firestation.IsActive && idFireSafetyDepartments.Contains(firestation.IdFireSafetyDepartment)
                select firestation;

            return query.ToList();
        }

		public List<FirestationForList> GetListLocalized(Guid idCity)
		{
			var result =
				from department in Context.FireSafetyDepartments.AsNoTracking()
				where department.FireSafetyDepartmentServing.Any(serving => serving.IdCity == idCity && serving.IsActive) && department.IsActive
				from station in department.Firestations
				where station.IsActive
				select new FirestationForList { Id = station.Id, Name = station.Name};

			return result.Distinct().ToList();
		}
	}
}