using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class StateService : BaseCrudService<State>
    {
        public StateService(ManagementContext context) : base(context)
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
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }
    }
}
