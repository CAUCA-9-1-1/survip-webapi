using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class StateService 
        : BaseCrudServiceWithImportation<State, ApiClient.DataTransferObjects.State>
    {
        public StateService(
            IManagementContext context, 
            IEntityConverter<ApiClient.DataTransferObjects.State, State> converter) 
            : base(context, converter)
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
    }
}
