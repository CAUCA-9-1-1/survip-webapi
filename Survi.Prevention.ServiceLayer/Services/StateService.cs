using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ServiceLayer.Import.Country;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class StateService : BaseCrudService<State>
    {
        public StateService(IManagementContext context) : base(context)
        {
        }

        public override State Get(Guid id)
        {
            var result = Context.States
                        .Include(s => s.Localizations)
                        .First(s => s.Id == id);

            return result;
        }

        public override List<State> GetList()
        {
            var result = Context.States
						.Where(s => s.IsActive)
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }

        public List<StateLocalized> GetListLocalized(string languageCode)
        {
            var query =
                from state in Context.States.AsNoTracking()
                where state.IsActive
                from localization in state.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode
                orderby localization.Name
                select new StateLocalized
                {
                    Id = state.Id,
                    Name = localization.Name
                };

            return query.ToList();
        }

	    public List<ImportationResult> ImportStates(List<ApiClient.DataTransferObjects.State> importedStates)
	    {
		    List<ImportationResult> resultList = new List<ImportationResult>();
		    foreach (var state in importedStates)
		    {
			    resultList.Add(ImportState(state));
		    }

		    return resultList;
	    }

	    public ImportationResult ImportState(ApiClient.DataTransferObjects.State importedState)
	    {
		    StateModelConnector connector = new StateModelConnector(Context);
		    ImportationResult result = connector.ValidateState(importedState);

		    if (result.HasBeenImported)
		    {
			    var newState = Context.States.Include(loc =>loc.Localizations).SingleOrDefault(c => c.IdExtern == importedState.Id);
			    bool isExistRecord = newState != null && newState.Id != Guid.Empty;

			    newState = connector.TransferDtoImportedToOriginal(importedState, newState?? new State());

			    if (!isExistRecord)
				    Context.States.Add(newState);
			    else
				    Context.States.Update(newState);

			    Context.SaveChanges();
			    result.HasBeenImported = true;
		    }
		    return result;
	    }
    }
}
